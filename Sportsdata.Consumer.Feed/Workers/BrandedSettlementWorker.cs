namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class BrandedSettlementWorker : WorkerBase
    {
        public BrandedSettlementWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static BrandedSettlementSettings LoadApplicationSettings(IConfiguration configuration)
        {
            BrandedSettlementSettings mySettings = new BrandedSettlementSettings();
            configuration.GetSection("BrandedSettlementSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);
    
            return mySettings;
        }
    }
}
