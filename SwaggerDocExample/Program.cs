using SwaggerDocExample.Config.ApiVersion;
using SwaggerDocExample.Config.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Adicionando classes de configuração de versionamento e Swagger personalizado
builder.Services.ConfigureApiVersioning();

builder.Services.SwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.SwaggerUi();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
