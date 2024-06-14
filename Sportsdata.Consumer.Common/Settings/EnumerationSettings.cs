namespace Sportsdata.Consumer.Common
{
    public class EnumerationSettings : KafkaSettings, IApplicationSettings
    {
        public EnumerationSettings()
        {
            this.Topic = default!;
        }
        public string Topic { get; set; }
    }
}
