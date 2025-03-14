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
