using Ch2_TheObserverPattern.Interfaces;

namespace Ch2_TheObserverPattern.Models
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private WeatherData _weatherData;

        public CurrentConditionsDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update()
        {
            _temperature = _weatherData.Temperature;
            _humidity = _weatherData.Humidity;
            Display();
        }

        public void Display() => Console.WriteLine($"Current conditions: {_temperature}°F " +
            $"and {_humidity}% humidity");

    }
}
