using DesignPatterns;
using DesignPatterns.App;
using DesignPatterns.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddApiServices();
services.AddApplication();
services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

#region AppConfig

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapControllers();

#endregion

app.Run();