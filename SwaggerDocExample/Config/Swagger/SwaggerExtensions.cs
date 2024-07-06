using Asp.Versioning.ApiExplorer;

namespace SwaggerDocExample.Config.Swagger
{
    public static class SwaggerExtensions
    {

        public static IServiceCollection SwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen();
            services.ConfigureOptions<ConfigureSwaggerOptions>();

            return services;
        }

        public static WebApplication SwaggerUi(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                    {
                        options.SwaggerEndpoint($"/swagger/{description.GroupName}.swagger.json", description.GroupName.ToUpperInvariant());
                    }
                });
            }

            return app;
        }
    }
}
