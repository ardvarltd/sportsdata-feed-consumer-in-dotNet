namespace Sportsdata.Consumer.Common
{
    public class LeagueSettings : KafkaSettings, IApplicationSettings
    {
        public LeagueSettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
