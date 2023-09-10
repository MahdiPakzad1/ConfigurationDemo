namespace BlazorApp1.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    private readonly IConfiguration config;

    public WeatherForecastService(IConfiguration config)
    {
        this.config = config;
    }
    public Task<WeatherForecast[]> GetForecastAsync(DateOnly startDate)
    {
        int upperValue = config.GetValue<int>("WeatherForecastdays");
        var startValue = config.GetValue<int>("Weather:StartNumber:value");

        return Task.FromResult(Enumerable.Range(startValue, upperValue).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }
}
