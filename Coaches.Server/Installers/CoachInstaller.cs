namespace Coaches.Server;

using Common.AssemplyScanning;
public class CoachInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {

        services.AddScoped<IValidator<CoachViewModel>, CoachValidator>();
        services.AddScoped<ICoachRepository, CoachRepository>();
        services.AddScoped<ICoachUnitOfWork, CoachUnitOfWork>();
    }
}
