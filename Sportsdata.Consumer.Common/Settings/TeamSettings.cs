namespace Sportsdata.Consumer.Common
{
    public class TeamSettings : KafkaSettings, IApplicationSettings
    {
        public TeamSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
