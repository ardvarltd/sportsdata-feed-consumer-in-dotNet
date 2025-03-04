namespace Sportsdata.Consumer.Common
{
    public class GamePeriodSettings : KafkaSettings, IApplicationSettings
    {
        public GamePeriodSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
