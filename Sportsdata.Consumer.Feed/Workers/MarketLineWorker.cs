namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class MarketLineWorker : WorkerBase
    {
        public MarketLineWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static MarketLineSettings LoadApplicationSettings(IConfiguration configuration)
        {
            MarketLineSettings mySettings = new MarketLineSettings();
            configuration.GetSection("MarketLineSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
