namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class EventWorker : WorkerBase
    {
        public EventWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static EventSettings LoadApplicationSettings(IConfiguration configuration)
        {
            EventSettings mySettings = new EventSettings();
            configuration.GetSection("EventSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
