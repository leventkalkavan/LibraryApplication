using Application.Repositories.BookRepositories;
using Application.Repositories.CustomerRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Repositories.BookRepositories;
using Persistence.Repositories.CustomerRepositories;

namespace Persistence;

// Bu sınıf, Persistence katmanı için servisleri yapılandırmak için kullanılır.
public static class ServiceRegistation
{
    // Persistence katmanı için servisleri eklemek için kullanılır.
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        // Entity Framework ile veritabanı bağlantısını yapılandırılır.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString));
        
        services.AddScoped<IBookReadRepository, BookReadRepository>();
        services.AddScoped<IBookWriteRepository, BookWriteRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
    }
}