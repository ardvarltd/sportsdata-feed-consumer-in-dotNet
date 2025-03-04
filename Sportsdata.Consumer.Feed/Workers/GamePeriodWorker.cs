namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class GamePeriodWorker : WorkerBase
    {
        public GamePeriodWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static GamePeriodSettings LoadApplicationSettings(IConfiguration configuration)
        {
            GamePeriodSettings mySettings = new GamePeriodSettings();
            configuration.GetSection("GamePeriodSettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
