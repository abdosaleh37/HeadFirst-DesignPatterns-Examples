using CH2_TheObserverPattern_WeatherApp.Interfaces;

namespace CH2_TheObserverPattern_WeatherApp.Models
{
    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private float _currentPressure;
        private float _lastPressure;
        private WeatherData _weatherData;

        public ForecastDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update()
        {
            _lastPressure = _currentPressure;
            _currentPressure = _weatherData.Pressure;
            Display();
        }

        public void Display()
        {
            Console.Write("Forecast: ");
            if (_currentPressure > _lastPressure)
            {
                Console.WriteLine("Improving weather on the way!");
            }
            else if (_currentPressure == _lastPressure)
            {
                Console.WriteLine("More of the same.");
            }
            else
            {
                Console.WriteLine("Watch out for cooler, rainy weather.");
            }
        }
    }
}
