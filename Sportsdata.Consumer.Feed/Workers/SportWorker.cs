namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class SportWorker : WorkerBase
    {
        public SportWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static SportSettings LoadApplicationSettings(IConfiguration configuration)
        {
            SportSettings mySettings = new SportSettings();
            configuration.GetSection("SportSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
