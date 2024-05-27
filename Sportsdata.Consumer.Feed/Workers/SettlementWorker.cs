namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class SettlementWorker : WorkerBase
    {
        public SettlementWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static SettlementSettings LoadApplicationSettings(IConfiguration configuration)
        {
            SettlementSettings mySettings = new SettlementSettings();
            configuration.GetSection("SettlementSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);
    
            return mySettings;
        }
    }
}
