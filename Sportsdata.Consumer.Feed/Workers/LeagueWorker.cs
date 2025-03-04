namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class LeagueWorker : WorkerBase
    {
        public LeagueWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static LeagueSettings LoadApplicationSettings(IConfiguration configuration)
        {
            LeagueSettings mySettings = new LeagueSettings();
            configuration.GetSection("LeagueSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
