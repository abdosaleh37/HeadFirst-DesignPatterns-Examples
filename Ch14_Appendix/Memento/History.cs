namespace Ch14_Appendix.Memento;

public sealed class History
{
    private readonly Stack<EditorMemento> _snapshots = new();

    public void Push(EditorMemento memento)
    {
        _snapshots.Push(memento);
    }

    public EditorMemento Pop() => _snapshots.Pop();
}
