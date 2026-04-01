using Ch14_Appendix.Bridge;
using Ch14_Appendix.Builder;
using Ch14_Appendix.ChainOfResponsibility;
using Ch14_Appendix.Flyweight;
using Ch14_Appendix.Interpreter;
using Ch14_Appendix.Mediator;
using Ch14_Appendix.Memento;
using Ch14_Appendix.Prototype;
using Ch14_Appendix.Visitor;

PrintHeader("CHAPTER 14 - APPENDIX: LEFTOVER PATTERNS", '=');
Console.WriteLine("This chapter demonstrates the remaining GoF patterns with focused demos.");

BridgeDemo.Run();
BuilderDemo.Run();
ChainDemo.Run();
FlyweightDemo.Run();
InterpreterDemo.Run();
MediatorDemo.Run();
MementoDemo.Run();
PrototypeDemo.Run();
VisitorDemo.Run();

PrintHeader("CHAPTER 14 SUMMARY", '=');
Console.WriteLine("You have now seen examples for all leftover appendix patterns.");

static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}
