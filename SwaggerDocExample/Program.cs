using SwaggerDocExample.Config.ApiVersion;
using SwaggerDocExample.Config.Swagger;
using SwaggerDocExample.Extensions;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddCors();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adicionando classes de configuração de versionamento e Swagger personalizado
builder.Services.ConfigureApiVersioning();

builder.Services.SwaggerGen();
builder.Services.AddConfigAuthentication(configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.SwaggerUi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(builder => builder
    .SetIsOriginAllowed(orign => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.MapControllers();

app.Run();
