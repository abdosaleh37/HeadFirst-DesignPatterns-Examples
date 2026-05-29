using Ch14_Appendix.Bridge;
using Ch14_Appendix.Builder;
using Ch14_Appendix.ChainOfResponsibility;
using Ch14_Appendix.Flyweight;
using Ch14_Appendix.Interpreter;
using Ch14_Appendix.Mediator;
using Ch14_Appendix.Memento;
using Ch14_Appendix.Prototype;
using Ch14_Appendix.Visitor;

PrintSection("Chapter 14 - Appendix: Leftover Patterns");
Console.WriteLine("Nine focused demos, one per remaining GoF pattern.");

var demos = new (string Title, Action Run)[]
{
    ("Bridge", BridgeDemo.Run),
    ("Builder", BuilderDemo.Run),
    ("Chain of Responsibility", ChainDemo.Run),
    ("Flyweight", FlyweightDemo.Run),
    ("Interpreter", InterpreterDemo.Run),
    ("Mediator", MediatorDemo.Run),
    ("Memento", MementoDemo.Run),
    ("Prototype", PrototypeDemo.Run),
    ("Visitor", VisitorDemo.Run)
};

foreach (var (title, run) in demos)
{
    PrintSection(title);
    run();
}

PrintSection("Summary");
Console.WriteLine("Appendix patterns complete.");

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}
