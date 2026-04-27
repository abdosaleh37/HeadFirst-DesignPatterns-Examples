using Ch02_TheObserverPattern.Models;

namespace Ch02_TheObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("─── Chapter 2 · Observer Pattern ───────────────────────────────");
            Console.WriteLine("Scenario: Weather station pushes updates to registered displays");
            Console.WriteLine();

            WeatherData weatherData = new WeatherData();

            _ = new CurrentConditionsDisplay(weatherData);
            _ = new StatisticsDisplay(weatherData);
            _ = new ForecastDisplay(weatherData);
            _ = new HeatIndexDisplay(weatherData);

            // Morning baseline report: mild temperature, moderate humidity, stable pressure.
            Console.WriteLine("Observers fired: CurrentConditions, Statistics, Forecast, HeatIndex");
            weatherData.SetMeasurements(80, 65, 30.4f);

            // Late morning shift: warmer air and dropping pressure indicate changing weather.
            Console.WriteLine();
            Console.WriteLine("Observers fired: CurrentConditions, Statistics, Forecast, HeatIndex");
            weatherData.SetMeasurements(82, 70, 29.2f);

            // Afternoon spike: humid conditions jump, useful for heat index behavior.
            Console.WriteLine();
            Console.WriteLine("Observers fired: CurrentConditions, Statistics, Forecast, HeatIndex");
            weatherData.SetMeasurements(78, 90, 29.2f);
        }
    }
}

