using DesignPatterns;
using DesignPatterns.App;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

#region Services

services.AddApiServices();
services.AddApplication();

#endregion

var app = builder.Build();

#region AppCfg

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapControllers();

#endregion

app.Run();