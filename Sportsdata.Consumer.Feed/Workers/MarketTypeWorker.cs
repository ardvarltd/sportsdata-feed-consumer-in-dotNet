namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class MarketTypeWorker : WorkerBase
    {
        public MarketTypeWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static MarketTypeSettings LoadApplicationSettings(IConfiguration configuration)
        {
            MarketTypeSettings mySettings = new MarketTypeSettings();
            configuration.GetSection("MarketTypeSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
