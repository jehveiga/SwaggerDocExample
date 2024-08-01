using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace SwaggerDocExample.Config.Swagger
{
    /// IApiVersionDescriptionProvider através do nosso construtor, 
    /// ela servirá para que tenhamos disponível de maneira automática todas as versões que temos na nossa API pois nela temos uma lista das mesmas.
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
            options.EnableAnnotations(); // Habilitar anotações

            foreach (var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }

            AddSecurityConfig(options);

            var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
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
                    Email = "meu_email@email.com"
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

        private void AddSecurityConfig(SwaggerGenOptions options)
        {
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
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                Array.Empty<string>()
                }
            });
        }
    }
}
