namespace Sportsdata.Consumer.Common
{
    public class CountrySettings : KafkaSettings, IApplicationSettings
    {
        public CountrySettings()
        {
            this.Topic = default!;
        }

        public string Topic { get; set; }
    }
}
