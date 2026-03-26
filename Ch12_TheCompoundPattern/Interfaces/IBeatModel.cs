namespace Ch12_TheCompoundPattern.Interfaces;

public interface IBeatModel
{
    void Initialize();
    void On();
    void Off();
    void SetBpm(int bpm);
    int GetBpm();

    void RegisterObserver(IBeatObserver observer);
    void RemoveObserver(IBeatObserver observer);

    void RegisterObserver(IBpmObserver observer);
    void RemoveObserver(IBpmObserver observer);
}