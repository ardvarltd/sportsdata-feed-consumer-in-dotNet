namespace Sportsdata.Consumer.Common
{
    public interface IApplicationSettings
    {
        public string Server { get; set; }

        public string SchemaRegistryUrl {get; set;}

        public string Key { get; set; }

        public string Secret { get; set; }

        public string Topic { get; set; }

        public string GroupId { get; set; }

        public string SecurityProtocol { get; set; }
        
        public string SaslMechanism { get; set; }
    }
}
