namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class TeamWorker : WorkerBase
    {
        public TeamWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static TeamSettings LoadApplicationSettings(IConfiguration configuration)
        {
            TeamSettings mySettings = new TeamSettings();
            configuration.GetSection("TeamSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
