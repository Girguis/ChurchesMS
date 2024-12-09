using AutoMapper;
using ChurchMS.API.Middlewares;
using ChurchMS.Application.Extensions;

namespace ChurchMS.API.Extensions;

public static class WebApplicationConfiguration
{
    public static IApplicationBuilder AddWebApplicationConfiguration(this WebApplication app)
    {
        //Mapper
        var mapper = app.Services.GetRequiredService<IMapper>();
        MapperService.AddMapperService(mapper);

        //Middleware
        app.UseMiddleware<ExceptionMiddleware>();

        return app;
    }
}