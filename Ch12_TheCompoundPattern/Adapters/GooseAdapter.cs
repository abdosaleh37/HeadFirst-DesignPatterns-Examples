using Ch12_TheCompoundPattern.Models;

namespace Ch12_TheCompoundPattern.Adapters;

public sealed class GooseAdapter : QuackableBase
{
    private readonly Goose _goose;

    public GooseAdapter(Goose goose)
    {
        _goose = goose;
    }

    public override string Name => "Goose (adapted as duck)";

    public override void Quack()
    {
        _goose.Honk();
        NotifyObservers();
    }
}