namespace Sportsdata.Consumer.Common
{
    public class EventSettings : KafkaSettings, IApplicationSettings
    {
        public EventSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
