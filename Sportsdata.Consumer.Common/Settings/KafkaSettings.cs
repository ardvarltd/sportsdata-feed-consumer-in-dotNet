namespace Sportsdata.Consumer.Common
{
    public class KafkaSettings
    {
        public KafkaSettings()
        {
            this.Server = default!;
            this.SchemaRegistryUrl = default!;
            this.Key = default!;
            this.Secret = default!;
            this.GroupId = default!;
            this.SecurityProtocol = default!;
            this.SaslMechanism = default!;
        }

        public string Server { get; set; }
        public string SchemaRegistryUrl { get; set; }
        public string Key { get; set; }
        public string Secret { get; set; }
        public string GroupId { get; set; }
        public string SecurityProtocol { get; set; }
        public string SaslMechanism { get; set; }
    }
}
