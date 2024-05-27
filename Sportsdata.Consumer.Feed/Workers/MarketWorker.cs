namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class MarketWorker : WorkerBase
    {
        public MarketWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static MarketSettings LoadApplicationSettings(IConfiguration configuration)
        {
            MarketSettings mySettings = new MarketSettings();
            configuration.GetSection("MarketSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);
    
            return mySettings;
        }
    }
}
