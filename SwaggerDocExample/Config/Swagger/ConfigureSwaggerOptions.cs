using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace SwaggerDocExample.Config.Swagger
{
    /// <summary>
    /// IApiVersionDescriptionProvider através do nosso construtor, 
    /// ela servirá para que tenhamos disponível de maneira automática todas as versões que temos na nossa API pois nela temos uma lista das mesmas.
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider _provider;

        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
            _provider = provider;
        }

        public void Configure(string? name, SwaggerGenOptions options)
        {
            Configure(options);
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));

            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Insira o token no padrão: Bearer {seu token}",
                Name = "Authorization",
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
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
                Array.Empty<string>()
                }
            });
        }

        private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            var info = new OpenApiInfo
            {
                Title = "Alunos",
                Description = "API para retorno de dados do aluno.",
                Contact = new OpenApiContact
                {
                    Name = "Meu email de contato",
                    Email = "mailto:meu_email@email.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Meu tipo de licença",
                    Url = new Uri("https://exemplo.com.licenca")
                },
                Version = description.ApiVersion.ToString()
            };

            if (description.IsDeprecated)
            {
                info.Description +=
                    "Esta versão da API foi depreciada, por favor utilizar uma mais recente disponível.";
            }

            return info;
        }
    }
}
