using BookManagement.Core.Persistence.Repositories;
using BookManagement.Infrastructure.Persistence.Repositories;
using BookManagement.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookManagement.Infrastructure;

public static class InfrastructureModule {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        services
            .AddPersistence(configuration)
            .AddRepositories()
            .AddUnitOfWork();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration) {
        string connectionString = configuration.GetConnectionString("BookManagerDb")!;

        services.AddDbContext<BookManagerDbContext>(options => options.UseSqlServer(connectionString));
        //services.AddDbContext<BookManagerDbContext>(options => options.UseInMemoryDatabase("BookManagerDb")); // Banco em memória

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services) {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services) {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}