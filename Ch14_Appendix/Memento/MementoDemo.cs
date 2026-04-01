namespace Ch14_Appendix.Memento;

public static class MementoDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Memento Pattern ---");

        var editor = new TextEditor();
        var history = new History();

        editor.Content = "Draft v1";
        history.Push(editor.Save());

        editor.Content = "Draft v2";
        history.Push(editor.Save());

        editor.Content = "Draft v3 (broken)";
        Console.WriteLine($"Current: {editor.Content}");

        editor.Restore(history.Pop());
        Console.WriteLine($"After undo: {editor.Content}");
    }
}
