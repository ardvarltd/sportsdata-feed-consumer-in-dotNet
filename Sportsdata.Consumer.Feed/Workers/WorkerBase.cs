namespace Sportsdata.Consumer.Common
{
    using Avro.Generic;
    using Confluent.Kafka;
    using Confluent.Kafka.SyncOverAsync;
    using Confluent.SchemaRegistry;
    using Confluent.SchemaRegistry.Serdes;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public abstract class WorkerBase : BackgroundService
    {
        protected readonly ILogger<WorkerBase> _logger;
        private readonly IApplicationSettings _settings;

        public WorkerBase(
            ILogger<WorkerBase> logger,
            IApplicationSettings settings)
        {
            _logger = logger;
            _settings = settings;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {

            using (var schemaRegistry = InitializeSchemaRegistry())
            using (var consumer = InitializeConsumer(schemaRegistry))
            {
                consumer.Subscribe(_settings.Topic);

                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        try
                        {
                            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                            var result = consumer.Consume(stoppingToken);

                            await ProcessMessage(result.Message.Value);


                        }
                        catch (ConsumeException e)
                        {
                            Console.WriteLine($"Consume error: {e.Error.Reason}");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    consumer.Close();
                }
            }

        }

        public Task ProcessMessage(GenericRecord genericRecord)
        {
            var messageContent = ExtractMessageContent(genericRecord);
            
            var processedMessage = "";
            processedMessage += "{";
            foreach (var kvp in messageContent)
            {
                 processedMessage += $"\"{kvp.Key}\": {JsonConvert.SerializeObject(kvp.Value)},";
            }
            processedMessage = processedMessage.TrimEnd(',');
            processedMessage += "}";
            // Parse the constructed JSON string to a JObject for reformatting
            var jsonObject = JObject.Parse(processedMessage);
            var formattedJsonString = JsonConvert.SerializeObject(jsonObject, Formatting.Indented);
            Console.WriteLine(formattedJsonString);

            return Task.CompletedTask;
        }

        private ISchemaRegistryClient InitializeSchemaRegistry()
        {
            SchemaRegistryConfig schemaConfig = new SchemaRegistryConfig();
            schemaConfig.Set("schema.registry.url", _settings.SchemaRegistryUrl);
            return new CachedSchemaRegistryClient(schemaConfig);
        }


        private IConsumer<string, GenericRecord> InitializeConsumer(ISchemaRegistryClient schemaRegistry)
        {
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = _settings.Server,
                GroupId = _settings.GroupId,
                SecurityProtocol = (SecurityProtocol)Enum.Parse(typeof(SecurityProtocol), _settings.SecurityProtocol),
                SaslMechanism = (SaslMechanism)Enum.Parse(typeof(SaslMechanism), _settings.SaslMechanism),
                SaslUsername = _settings.Key,
                SaslPassword = _settings.Secret,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            return new ConsumerBuilder<string, GenericRecord>(consumerConfig)
                .SetValueDeserializer(new AvroDeserializer<GenericRecord>(schemaRegistry).AsSyncOverAsync())
                .SetErrorHandler((_, e) => Console.WriteLine($"Error: {e.Reason}"))
                .Build();
        }
        private static object ExtractFieldValue(object fieldValue)
        {
            if (fieldValue is GenericRecord nestedRecord)
            {
                return ExtractMessageContent(nestedRecord);
            }
            else if (fieldValue is IList<GenericRecord> recordList)
            {
                var nestedList = new List<Dictionary<string, object>>();
                foreach (var item in recordList)
                {
                    nestedList.Add(ExtractMessageContent(item));
                }
                return nestedList;
            }
            else if (fieldValue is IList<object> genericList)
            {
                var nestedList = new List<object>();
                foreach (var item in genericList)
                {
                    nestedList.Add(ExtractFieldValue(item));
                }
                return nestedList;
            }
            else if (fieldValue is IDictionary<string, object> genericMap)
            {
                var nestedMap = new Dictionary<string, object>();
                foreach (var kvp in genericMap)
                {
                    nestedMap[kvp.Key] = ExtractFieldValue(kvp.Value);
                }
                return nestedMap;
            }
            else if (fieldValue is IDictionary<string, GenericRecord> recordMap)
            {
                var nestedMap = new Dictionary<string, object>();
                foreach (var kvp in recordMap)
                {
                    nestedMap[kvp.Key] = ExtractMessageContent(kvp.Value);
                }
                return nestedMap;
            }
            else if (fieldValue is IDictionary<string, IDictionary<string, GenericRecord>> nestedRecordMap)
            {
                var nestedMap = new Dictionary<string, object>();
                foreach (var kvp in nestedRecordMap)
                {
                    var innerMap = new Dictionary<string, object>();
                    foreach (var innerKvp in kvp.Value)
                    {
                        innerMap[innerKvp.Key] = ExtractMessageContent(innerKvp.Value);
                    }
                    nestedMap[kvp.Key] = innerMap;
                }
                return nestedMap;
            }
            else
            {
                return fieldValue;
            }
        }

        private static Dictionary<string, object> ExtractMessageContent(GenericRecord genericRecord)
        {
            var messageContent = new Dictionary<string, object>();

            foreach (var field in genericRecord.Schema.Fields)
            {
                var fieldName = field.Name;
                var fieldValue = genericRecord[fieldName];
                messageContent[fieldName] = ExtractFieldValue(fieldValue);
            }

            return messageContent;
        }
    }
}