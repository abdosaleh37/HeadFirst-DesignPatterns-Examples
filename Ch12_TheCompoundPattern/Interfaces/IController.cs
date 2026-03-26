namespace Ch12_TheCompoundPattern.Interfaces;

public interface IController
{
    void Start();
    void Stop();
    void IncreaseBpm();
    void DecreaseBpm();
    void SetBpm(int bpm);
}