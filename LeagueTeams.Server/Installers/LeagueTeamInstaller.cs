namespace LeagueTeams.Server;

using Common.AssemplyScanning;
public class LeagueTeamInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<LeagueTeamViewModel>, LeagueTeamValidator>();
        services.AddScoped<ILeagueTeamRepository, LeagueTeamRepository>();
        services.AddScoped<ILeagueTeamUnitOfWork, LeagueTeamUnitOfWork>();
    }
}
