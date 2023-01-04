namespace Common.AssemplyScanning
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public interface IInstaller
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }


}

