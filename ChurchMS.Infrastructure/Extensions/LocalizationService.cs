using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

namespace ChurchMS.Infrastructure.Extensions;

internal static class LocalizationService
{
    internal static IServiceCollection AddLocalizationService(this IServiceCollection services)
    {
        services.AddLocalization(options => options.ResourcesPath = "Resources");

        // Configure supported cultures
        var supportedCultures = new[]
        {
            new CultureInfo("en"),
            new CultureInfo("ar")
        };

        services.Configure<RequestLocalizationOptions>(options =>
        {
            options.DefaultRequestCulture = new RequestCulture("ar");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            options.RequestCultureProviders.Add(new AcceptLanguageHeaderRequestCultureProvider());
            options.RequestCultureProviders.Add(new CookieRequestCultureProvider());
            options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider());
        });

        return services;
    }
}