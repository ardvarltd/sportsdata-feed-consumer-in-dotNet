namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class CountryWorker : WorkerBase
    {
        public CountryWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static CountrySettings LoadApplicationSettings(IConfiguration configuration)
        {
            CountrySettings mySettings = new CountrySettings();
            configuration.GetSection("CountrySettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
