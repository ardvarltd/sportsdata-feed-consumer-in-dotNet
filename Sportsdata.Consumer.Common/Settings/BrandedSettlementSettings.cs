namespace Sportsdata.Consumer.Common
{
    public class BrandedSettlementSettings : KafkaSettings, IApplicationSettings
    {
        public BrandedSettlementSettings()
        {
            this.Topic = default!;
        }
        public string Topic { get; set; }
    }
}
