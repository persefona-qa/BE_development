using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NDubko.Application.Options;
using NDubko.Database.Repositories;
using NDubko.Database;
using Microsoft.EntityFrameworkCore;
using NDubko.Api.ExceptionHandling;
using Microsoft.Extensions.Options;

namespace NDubko.Api;

public static class ServiceCollectionExtention
{
    /// <summary>
    /// Task for #6 Create Authentication and Authorization method (Bearer token / JWT)
    /// </summary>
    public static IServiceCollection AddAuth(this IServiceCollection serviceCollection)
    {
        ServiceProvider services = serviceCollection.BuildServiceProvider();
        var authOptions = services.GetService<IOptions<AuthOptions>>();

        serviceCollection
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = authOptions.Value.Issuer,
                ValidateAudience = true,
                ValidAudience = authOptions.Value.Audience,
                ValidateLifetime = true,
                IssuerSigningKey = authOptions.Value.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        });
        
       return serviceCollection
            .AddAuthorization()
            .AddSwaggerGen(swaggerGenOptions =>
        {
            swaggerGenOptions.AddSecurityDefinition(
                "Bearer",
                new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization Header using Bearer Scheme.",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

            swaggerGenOptions.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header
                },
                new List<string>()
            }
                });
        });
    }

    /// <summary>
    /// Task for #4
    /// Move all DAL(data access layer to Repositories), do not use dbContext in Controllers.
    /// </summary>
    public static IServiceCollection AddDb(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddDbContext<LibraryDatabaseContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("LibraryDatabase")));

        serviceCollection.AddScoped<IAuthorRepository, AuthorRepository>();
        serviceCollection.AddScoped<IBookRepository, BookRepository>();

        return serviceCollection;
    }

    /// <summary>
    /// Task for #7 Exceptions Handlings
    /// </summary>
    public static IServiceCollection AddCustomExceptionHandling(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddProblemDetails();
        serviceCollection.AddExceptionHandler<CustomExceptionHandler>();

        return serviceCollection;
    }

    /// <summary>
    /// //Task for #8 Configuration (Options Pattern)
    /// </summary>
    public static IServiceCollection ConfigureOptions(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection.Configure<AuthOptions>(configuration.GetSection(nameof(AuthOptions)));
    }
}
