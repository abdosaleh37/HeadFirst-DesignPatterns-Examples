namespace Ch14_Appendix.Memento;

public sealed class TextEditor
{
    public string Content { get; set; } = string.Empty;

    public EditorMemento Save() => new(Content);

    public void Restore(EditorMemento memento)
    {
        Content = memento.Content;
    }
}
