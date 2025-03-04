namespace Sportsdata.Consumer.Common
{
    public class LineEntitySettings : KafkaSettings, IApplicationSettings
    {
        public LineEntitySettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
