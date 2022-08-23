using AsyncAwaitLab.Options;
using AsyncAwaitLab.Service;
using AsyncAwaitLab.Service.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddOptions<JokeHttpOptions>()
                .Configure<IConfiguration>((options, configuration) =>
                {
                    configuration.GetSection(nameof(JokeHttpOptions)).Bind(options);
                }).ValidateDataAnnotations();

builder.Services.AddOptions<WeatherHttpOptions>()
                .Configure<IConfiguration>((options, configuration) =>
                {
                    configuration.GetSection(nameof(WeatherHttpOptions)).Bind(options);
                }).ValidateDataAnnotations();

builder.Services.AddScoped<IJokeService, JokeService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddHttpClient<JokeHttpClient>();
builder.Services.AddHttpClient<WeatherHttpClient>();


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
