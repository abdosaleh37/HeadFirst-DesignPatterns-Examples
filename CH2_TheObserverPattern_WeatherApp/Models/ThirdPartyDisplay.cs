using CH2_TheObserverPattern_WeatherApp.Interfaces;

namespace CH2_TheObserverPattern_WeatherApp.Models
{
    public class ThirdPartyDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        private WeatherData _weatherData;

        public ThirdPartyDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update()
        {
            _temperature = _weatherData.Temperature;
            _humidity = _weatherData.Humidity;
            _pressure = _weatherData.Pressure;
            Display();
        }
        public void Display()
        {
            Console.WriteLine($"Third Party Display - Temp: {_temperature}°F, Humidity: {_humidity}%, Pressure: {_pressure} hPa");
        }
    }
}
