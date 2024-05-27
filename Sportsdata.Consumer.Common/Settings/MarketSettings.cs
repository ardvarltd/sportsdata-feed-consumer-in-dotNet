namespace Sportsdata.Consumer.Common
{
    public class MarketSettings : KafkaSettings, IApplicationSettings
    {
        public MarketSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
