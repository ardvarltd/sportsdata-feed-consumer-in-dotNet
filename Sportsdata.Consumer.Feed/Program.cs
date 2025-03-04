using Sportsdata.Consumer.Common;
using Sportsdata.Consumer.Feed;
using Microsoft.Extensions.Options;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {

        switch (Environment.GetEnvironmentVariable("PROFILE"))
        {
            case "Event":
                InjectSettings<EventWorker>(hostContext, services, new EventSettings());
                break;
            case "Market":
                InjectSettings<MarketWorker>(hostContext, services, new MarketSettings());
                break;
            case "Settlement":
                InjectSettings<SettlementWorker>(hostContext, services, new SettlementSettings());
                break;
            case "Enumeration":
                InjectSettings<EnumerationWorker>(hostContext, services, new EnumerationSettings());
                break;
            case "Country":
                InjectSettings<CountryWorker>(hostContext, services, new CountrySettings());
                break;
            case "GamePeriod":
                InjectSettings<GamePeriodWorker>(hostContext, services, new GamePeriodSettings());
                break;
            case "League":
                InjectSettings<LeagueWorker>(hostContext, services, new LeagueSettings());
                break;
            case "LineEntity":
                InjectSettings<LineEntityWorker>(hostContext, services, new LineEntitySettings());
                break;
            case "MarketLine":
                InjectSettings<MarketLineWorker>(hostContext, services, new MarketLineSettings());
                break;
            case "MarketType":
                InjectSettings<MarketTypeWorker>(hostContext, services, new MarketTypeSettings());
                break;
            case "Sport":
                InjectSettings<SportWorker>(hostContext, services, new SportSettings());
                break;
            case "Team":
                InjectSettings<TeamWorker>(hostContext, services, new TeamSettings());
                break;
            default:
                break;
        }
    })
    .Build();

void InjectSettings<WorkerBase>(HostBuilderContext hostContext, IServiceCollection services, IApplicationSettings settings)
        where WorkerBase : class, IHostedService
{
    services.AddSingleton(provider =>
    {
        var kafkaSettings = provider.GetRequiredService<IOptions<KafkaSettings>>().Value;
        var section = hostContext.Configuration.GetSection(nameof(settings));
        SetSettings(kafkaSettings, section, settings);
        return settings;
    })
    .AddHostedService<WorkerBase>();
}

await host.RunAsync();

static void SetSettings(KafkaSettings kafkaSettings, IConfigurationSection section, IApplicationSettings settings)
{
    settings.Server = kafkaSettings.Server;
    settings.SchemaRegistryUrl = kafkaSettings.SchemaRegistryUrl;
    settings.Key = kafkaSettings.Key;
    settings.Secret = kafkaSettings.Secret;
    settings.GroupId = kafkaSettings.GroupId;
    settings.SecurityProtocol = kafkaSettings.SecurityProtocol;
    settings.SaslMechanism = kafkaSettings.SaslMechanism;
    settings.Topic = section.GetValue<string>("Topic");
}