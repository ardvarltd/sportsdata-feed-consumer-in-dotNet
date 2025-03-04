namespace Sportsdata.Consumer.Common
{
    public class MarketTypeSettings : KafkaSettings, IApplicationSettings
    {
        public MarketTypeSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
