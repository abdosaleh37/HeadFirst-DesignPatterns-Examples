using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Models.MVC;

public sealed class BeatModel : IBeatModel
{
    private readonly List<IBeatObserver> _beatObservers = new();
    private readonly List<IBpmObserver> _bpmObservers = new();
    private int _bpm;

    public void Initialize()
    {
        _bpm = 0;
    }

    public void On()
    {
        SetBpm(90);
        NotifyBeatObservers();
    }

    public void Off()
    {
        SetBpm(0);
    }

    public void SetBpm(int bpm)
    {
        _bpm = Math.Clamp(bpm, 0, 240);
        NotifyBpmObservers();
    }

    public int GetBpm() => _bpm;

    public void RegisterObserver(IBeatObserver observer)
    {
        if (!_beatObservers.Contains(observer))
        {
            _beatObservers.Add(observer);
        }
    }

    public void RemoveObserver(IBeatObserver observer)
    {
        _beatObservers.Remove(observer);
    }

    public void RegisterObserver(IBpmObserver observer)
    {
        if (!_bpmObservers.Contains(observer))
        {
            _bpmObservers.Add(observer);
        }
    }

    public void RemoveObserver(IBpmObserver observer)
    {
        _bpmObservers.Remove(observer);
    }

    public void SimulateBeats(int count)
    {
        if (_bpm <= 0)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            NotifyBeatObservers();
        }
    }

    private void NotifyBeatObservers()
    {
        foreach (var observer in _beatObservers)
        {
            observer.UpdateBeat();
        }
    }

    private void NotifyBpmObservers()
    {
        foreach (var observer in _bpmObservers)
        {
            observer.UpdateBpm();
        }
    }
}