using CH2_TheObserverPattern_WeatherApp.Interfaces;

namespace CH2_TheObserverPattern_WeatherApp.Models
{
    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float _maxTemp = float.MinValue;
        private float _minTemp = float.MaxValue;
        private float _tempSum = 0.0f;
        private int _numReadings = 0;
        private WeatherData _weatherData;

        public StatisticsDisplay(WeatherData weatherData)
        {
            _weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        public void Update()
        {
            float temp = _weatherData.Temperature;
            _tempSum += temp;
            _numReadings++;

            if (temp > _maxTemp)
            {
                _maxTemp = temp;
            }

            if (temp < _minTemp)
            {
                _minTemp = temp;
            }

            Display();
        }

        public void Display()
        {
            float avgTemp = _tempSum / _numReadings;
            Console.WriteLine($"Avg/Max/Min temperature = {avgTemp:F1}/{_maxTemp:F1}/{_minTemp:F1}°F");
        }
    }
}
