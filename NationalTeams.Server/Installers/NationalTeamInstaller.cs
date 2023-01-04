namespace NationalTeams.Server;

using Common.AssemplyScanning;
public class NationalTeamInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<NationalTeamViewModel>, NationalTeamValidator>();
        services.AddScoped<INationalTeamRepository, NationalTeamRepository>();
        services.AddScoped<INationalTeamUnitOfWork, NationalTeamUnitOfWork>();
    }
}
