namespace Sportsdata.Consumer.Feed
{
    using Sportsdata.Consumer.Common;
    using Microsoft.Extensions.Logging;

    public class LineEntityWorker : WorkerBase
    {
        public LineEntityWorker(
            ILogger<WorkerBase> logger, IConfiguration configuration) : base(logger, LoadApplicationSettings(configuration))
        { }

        private static LineEntitySettings LoadApplicationSettings(IConfiguration configuration)
        {
            LineEntitySettings mySettings = new LineEntitySettings();
            configuration.GetSection("LineEntitySettings").Bind(mySettings);
            configuration.GetSection("KafkaSettings").Bind(mySettings);

            return mySettings;
        }
    }
}
