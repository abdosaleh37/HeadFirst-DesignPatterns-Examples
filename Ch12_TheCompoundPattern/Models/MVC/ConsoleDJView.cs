using Ch12_TheCompoundPattern.Interfaces;

namespace Ch12_TheCompoundPattern.Models.MVC;

public sealed class ConsoleDJView : IBeatObserver, IBpmObserver
{
    private readonly IBeatModel _model;
    private IController? _controller;

    public ConsoleDJView(IBeatModel model)
    {
        _model = model;
        _model.RegisterObserver((IBeatObserver)this);
        _model.RegisterObserver((IBpmObserver)this);
    }

    public void SetController(IController controller)
    {
        _controller = controller;
    }

    public void ShowUi()
    {
        Console.WriteLine("Console DJ View is ready.");
        Console.WriteLine("Available controls: start, stop, increase bpm, decrease bpm, set bpm.");
    }

    public void UpdateBeat()
    {
        Console.WriteLine("View: Boom boom (beat event).");
    }

    public void UpdateBpm()
    {
        int bpm = _model.GetBpm();
        if (bpm == 0)
        {
            Console.WriteLine("View: BPM is offline.");
            return;
        }

        Console.WriteLine($"View: Current BPM is {bpm}.");
    }

    public void DemoUserActionSetBpm(int bpm)
    {
        _controller?.SetBpm(bpm);
    }
}