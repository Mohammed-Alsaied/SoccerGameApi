namespace Nationalities.Server;

using Common.AssemplyScanning;
public class NationalityInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<NationalityViewModel>, NationalityValidator>();
        services.AddScoped<INationalityRepository, NationalityRepository>();
        services.AddScoped<INationalityUnitOfWork, NationalityUnitOfWork>();
    }
}
