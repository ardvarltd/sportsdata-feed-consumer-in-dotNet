namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class EnumerationWorker : WorkerBase
    {
        public EnumerationWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static EnumerationSettings LoadApplicationSettings(IConfiguration configuration)
        {
            EnumerationSettings mySettings = new EnumerationSettings();
            configuration.GetSection("EnumerationSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);
    
            return mySettings;
        }
    }
}
