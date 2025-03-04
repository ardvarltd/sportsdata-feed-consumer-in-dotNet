namespace Sportsdata.Consumer.Common
{
    public class SportSettings : KafkaSettings, IApplicationSettings
    {
        public SportSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
