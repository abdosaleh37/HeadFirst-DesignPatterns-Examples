using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Models.MVC;

public sealed class BeatController : IController
{
    private readonly IBeatModel _model;

    public BeatController(IBeatModel model)
    {
        _model = model;
    }

    public void Start()
    {
        _model.On();
    }

    public void Stop()
    {
        _model.Off();
    }

    public void IncreaseBpm()
    {
        _model.SetBpm(_model.GetBpm() + 5);
    }

    public void DecreaseBpm()
    {
        _model.SetBpm(_model.GetBpm() - 5);
    }

    public void SetBpm(int bpm)
    {
        _model.SetBpm(bpm);
    }
}