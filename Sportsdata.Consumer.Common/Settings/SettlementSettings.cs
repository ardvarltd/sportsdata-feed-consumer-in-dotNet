namespace Sportsdata.Consumer.Common
{
    public class SettlementSettings : KafkaSettings, IApplicationSettings
    {
        public SettlementSettings()
        {
            this.Topic = default!;
        }
        public string Topic { get; set; }
    }
}
