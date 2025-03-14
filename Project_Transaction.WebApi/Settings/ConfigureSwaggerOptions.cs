using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
/*
namespace Testovoe_unistream_shashkin_a_a.WebApi.Settings
{

    public class ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, IWebHostEnvironment env) : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider = provider;
        private readonly IWebHostEnvironment env = env;

        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Введите 'Bearer' [пробел] и ваш токен в поле ниже для авторизации.",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });

            foreach (var version in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(version.GroupName, new OpenApiInfo()
                {
                    Title = env.ApplicationName,
                    Version = version.GroupName
                });
            }
        }
    }

}*/
