using Ch02_TheObserverPattern.Interfaces;

namespace Ch02_TheObserverPattern.Models
{
    public class WeatherData : ISubject
    {
        public List<IObserver> Observers { get; private set; }
        public float Temperature { get; private set; }
        public float Humidity { get; private set; }
        public float Pressure { get; private set; }

        public WeatherData() => Observers = new List<IObserver>();

        public void RegisterObserver(IObserver o) => Observers.Add(o);

        public void RemoveObserver(IObserver o) => Observers.Remove(o);

        public void NotifyObservers()
        {
            foreach (var observer in Observers)
            {
                observer.Update();
            }
        }

        public void MeasurementsChanged() => NotifyObservers();

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            Temperature = temperature;
            Humidity = humidity;
            Pressure = pressure;
            MeasurementsChanged();
        }
    }
}

