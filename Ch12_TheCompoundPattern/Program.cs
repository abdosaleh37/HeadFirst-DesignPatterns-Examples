using Ch12_TheCompoundPattern.Adapters;
using Ch12_TheCompoundPattern.Composites;
using Ch12_TheCompoundPattern.Decorators;
using Ch12_TheCompoundPattern.Factories;
using Ch12_TheCompoundPattern.Interfaces;
using Ch12_TheCompoundPattern.Models;
using Ch12_TheCompoundPattern.Models.MVC;
using Ch12_TheCompoundPattern.Observers;

PrintHeader("CHAPTER 12 - THE COMPOUND PATTERN", '=');
Console.WriteLine(
    """
    A Compound Pattern combines multiple patterns to solve a larger problem.

    This chapter demonstrates two examples from the book:
      1. Duck Simulator (Adapter + Decorator + Abstract Factory + Composite + Observer)
      2. MVC architecture (Model + View + Controller, with Observer at the core)
    """);

RunDuckSimulatorDemo();
RunMvcDemo();

PrintHeader("SUMMARY", '=');
Console.WriteLine(
    """
    Key takeaways:
      - Compound Pattern is not a single GoF pattern; it is pattern composition.
      - Duck Simulator shows how small patterns remain independent yet cooperative.
      - MVC demonstrates an architectural compound where responsibilities stay separated.
    """);

static void RunDuckSimulatorDemo()
{
    PrintHeader("PART 1: Duck Simulator Compound", '-');

    QuackCounter.Reset();
    IAbstractDuckFactory duckFactory = new CountingDuckFactory();

    IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
    IQuackable duckCall = duckFactory.CreateDuckCall();
    IQuackable rubberDuck = duckFactory.CreateRubberDuck();
    IQuackable gooseDuck = new GooseAdapter(new Goose());

    var flockOfDucks = new Flock();
    flockOfDucks.Add(redheadDuck);
    flockOfDucks.Add(duckCall);
    flockOfDucks.Add(rubberDuck);
    flockOfDucks.Add(gooseDuck);

    var flockOfMallards = new Flock();
    flockOfMallards.Add(duckFactory.CreateMallardDuck());
    flockOfMallards.Add(duckFactory.CreateMallardDuck());
    flockOfMallards.Add(duckFactory.CreateMallardDuck());
    flockOfMallards.Add(duckFactory.CreateMallardDuck());

    flockOfDucks.Add(flockOfMallards);

    var quackologist = new Quackologist();
    flockOfDucks.RegisterObserver(quackologist);

    Console.WriteLine("Duck simulation output:");
    Simulate(flockOfDucks);

    Console.WriteLine();
    Console.WriteLine($"The ducks quacked {QuackCounter.NumberOfQuacks} times.");
    Console.WriteLine("(The adapted goose honks but is not counted by QuackCounter.)");
}

static void RunMvcDemo()
{
    PrintHeader("PART 2: MVC (Beat Model)", '-');

    var beatModel = new BeatModel();
    IBeatModel model = beatModel;
    IController controller = new BeatController(model);
    var view = new ConsoleDJView(model);
    view.SetController(controller);

    model.Initialize();
    view.ShowUi();

    Console.WriteLine();
    Console.WriteLine("Controller action: Start");
    controller.Start();
    beatModel.SimulateBeats(2);

    Console.WriteLine();
    Console.WriteLine("Controller action: Increase BPM");
    controller.IncreaseBpm();
    beatModel.SimulateBeats(2);

    Console.WriteLine();
    Console.WriteLine("Controller action: Set BPM to 120");
    view.DemoUserActionSetBpm(120);
    beatModel.SimulateBeats(2);

    Console.WriteLine();
    Console.WriteLine("Controller action: Decrease BPM");
    controller.DecreaseBpm();
    beatModel.SimulateBeats(1);

    Console.WriteLine();
    Console.WriteLine("Controller action: Stop");
    controller.Stop();
}

static void Simulate(IQuackable duck)
{
    duck.Quack();
}

static void PrintHeader(string title, char separator)
{
    string line = new string(separator, 79);
    Console.WriteLine();
    Console.WriteLine(line);
    Console.WriteLine($"  {title}");
    Console.WriteLine(line);
}