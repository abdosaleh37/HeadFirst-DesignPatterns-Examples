using Ch06_TheCommandPattern.Commands;
using Ch06_TheCommandPattern.Devices;
using Ch06_TheCommandPattern.Interfaces;
using Ch06_TheCommandPattern.RemoteControls;

namespace Ch06_TheCommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSection("Chapter 6 - Command Pattern");

            DemoSimpleOnOff();
            DemoUndo();
            DemoMacro();

            Console.WriteLine();
            Console.WriteLine("Demo complete.");
        }

        private static void DemoSimpleOnOff()
        {
            PrintSection("1) Simple on/off command");

            var remote = new SimpleRemoteControl();
            var light = new Light("Living Room");

            remote.Slot = new LightOnCommand(light);
            Console.WriteLine("Pressing button (Light ON)");
            remote.ButtonWasPressed();

            remote.Slot = new LightOffCommand(light);
            Console.WriteLine("Pressing button (Light OFF)");
            remote.ButtonWasPressed();
        }

        private static void DemoUndo()
        {
            PrintSection("2) Undo demonstration");

            var remote = new RemoteControlWithUndo(2);
            var light = new Light("Living Room");
            var ceilingFan = new CeilingFan("Living Room");

            remote.SetCommand(0, new LightOnCommand(light), new LightOffCommand(light));
            remote.SetCommand(1, new CeilingFanHighCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));

            Console.WriteLine(remote);

            Console.WriteLine("Light ON, then UNDO");
            remote.OnButtonWasPushed(0);
            remote.UndoButtonWasPushed();

            Console.WriteLine("Fan HIGH, then UNDO");
            remote.OnButtonWasPushed(1);
            remote.UndoButtonWasPushed();
        }

        private static void DemoMacro()
        {
            PrintSection("3) Macro command");

            var remote = new RemoteControlWithUndo(1);
            var light = new Light("Living Room");
            var stereo = new Stereo("Living Room");
            var ceilingFan = new CeilingFan("Living Room");

            var partyOn = new MacroCommand(new List<ICommand>
            {
                new LightOnCommand(light),
                new StereoOnWithCDCommand(stereo),
                new CeilingFanMediumCommand(ceilingFan)
            });

            var partyOff = new MacroCommand(new List<ICommand>
            {
                new LightOffCommand(light),
                new StereoOffCommand(stereo),
                new CeilingFanOffCommand(ceilingFan)
            });

            remote.SetCommand(0, partyOn, partyOff);

            Console.WriteLine("Party ON");
            remote.OnButtonWasPushed(0);

            Console.WriteLine("Party OFF");
            remote.OffButtonWasPushed(0);

            Console.WriteLine("UNDO (runs macro undo)");
            remote.UndoButtonWasPushed();
        }

        private static void PrintSection(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 60));
        }
    }
}
