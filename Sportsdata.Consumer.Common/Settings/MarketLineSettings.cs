namespace Sportsdata.Consumer.Common
{
    public class MarketLineSettings : KafkaSettings, IApplicationSettings
    {
        public MarketLineSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
