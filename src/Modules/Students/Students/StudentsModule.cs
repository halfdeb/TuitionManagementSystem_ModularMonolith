using Microsoft.Extensions.DependencyInjection;

namespace Students;

public class StudentsModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        return services;
    }
}