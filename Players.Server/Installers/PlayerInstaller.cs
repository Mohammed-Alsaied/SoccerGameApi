namespace Players.Server;
using Common.AssemplyScanning;
public class PlayerInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<PlayerViewModel>, PlayerValidator>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IPlayerUnitOfWork, PlayerUnitOfWork>();
    }
}
