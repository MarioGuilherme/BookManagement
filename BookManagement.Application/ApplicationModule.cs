using BookManagement.Application.Commands.CreateBook;
using BookManagement.Application.Commands.CreateLoan;
using BookManagement.Application.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.Application;

public static class ApplicationModule {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        services
            .AddMediatR()
            .AddFluentValidation();

        return services;
    }

    private static IServiceCollection AddMediatR(this IServiceCollection services) {
        services.AddMediatR(opt => opt.RegisterServicesFromAssemblyContaining<CreateBookCommand>());

        services.AddTransient<IPipelineBehavior<CreateLoanCommand, Unit>, ValidateCreateLoanCommandBehavior>();

        return services;
    }

    private static IServiceCollection AddFluentValidation(this IServiceCollection services) {
        services.AddFluentValidationAutoValidation(opt => opt.DisableDataAnnotationsValidation = true);
        services.AddValidatorsFromAssemblyContaining<CreateBookValidator>();

        return services;
    }
}