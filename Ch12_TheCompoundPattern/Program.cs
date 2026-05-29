using Ch12_TheCompoundPattern.Adapters;
using Ch12_TheCompoundPattern.Composites;
using Ch12_TheCompoundPattern.Decorators;
using Ch12_TheCompoundPattern.Factories;
using Ch12_TheCompoundPattern.Interfaces;
using Ch12_TheCompoundPattern.Models;
using Ch12_TheCompoundPattern.Models.MVC;
using Ch12_TheCompoundPattern.Observers;

PrintSection("Chapter 12 - Compound Pattern");
Console.WriteLine("Duck Simulator + MVC compound examples");

RunDuckSimulatorDemo();
RunMvcDemo();

PrintSection("Summary");
Console.WriteLine("Compound patterns combine focused roles into one coherent system.");

static void RunDuckSimulatorDemo()
{
    PrintSection("Duck Simulator (Adapter, Decorator, Abstract Factory, Composite, Observer)");

    Console.WriteLine("Adapter: GooseAdapter makes a goose quackable.");
    Console.WriteLine("Decorator: QuackCounter tracks quacks.");
    Console.WriteLine("Abstract Factory: CountingDuckFactory creates wrapped ducks.");
    Console.WriteLine("Composite: Flock groups ducks.");
    Console.WriteLine("Observer: Quackologist listens for quacks.");

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
    PrintSection("MVC (Beat Model)");

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

static void PrintSection(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('-', 60));
    Console.WriteLine(title);
    Console.WriteLine(new string('-', 60));
}