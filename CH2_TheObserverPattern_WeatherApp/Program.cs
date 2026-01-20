using Ch2_TheObserverPattern_WeatherApp.Models;

namespace Ch2_TheObserverPattern_WeatherApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WeatherData weatherData = new WeatherData();

            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);

            weatherData.SetMeasurements(80, 65, 30.4f);
            Console.WriteLine("========================================================================");
            weatherData.SetMeasurements(82, 70, 29.2f);
            Console.WriteLine("========================================================================");
            weatherData.SetMeasurements(78, 90, 29.2f);
            Console.WriteLine("========================================================================");
        }
    }
}
