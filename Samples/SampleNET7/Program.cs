using SampleNET7.Application;
using SampleNET7.Application.Messages.Commands;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var generator = new FluentValidationGenerator.Generator(
	typeof(CreateWeatherForecastCommand).Assembly,
	Path.GetDirectoryName(
		Path.GetDirectoryName(
			Directory.GetCurrentDirectory()))!);

generator.GenerateValidators();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
