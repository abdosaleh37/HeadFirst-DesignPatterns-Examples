using Ch6_TheCommandPattern_RemoteControl.Commands;
using Ch6_TheCommandPattern_RemoteControl.Devices;
using Ch6_TheCommandPattern_RemoteControl.RemoteControls;

namespace Ch6_TheCommandPattern_RemoteControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===================================================");
            Console.WriteLine("       COMMAND PATTERN - REMOTE CONTROL DEMO       ");
            Console.WriteLine("===================================================\n");

            // Demo 1: Simple Remote Control (One Button)
            DemoSimpleRemote();

            Console.WriteLine("\n\n");

            // Demo 2: Standard Remote Control (Multiple Slots, No Undo)
            DemoStandardRemote();

            Console.WriteLine("\n\n");

            // Demo 3: Remote Control with Undo
            DemoRemoteWithUndo();

            Console.WriteLine("\n\n");

            // Demo 4: Remote Control with Multiple Undos (Stack)
            DemoRemoteWithMultipleUndos();

            Console.WriteLine("\n\n");

            // Demo 5: Macro Commands (Party Mode!)
            DemoMacroCommand();

            Console.WriteLine("\n");
            Console.WriteLine("===================================================");
            Console.WriteLine("                   DEMO COMPLETE!                  ");
            Console.WriteLine("===================================================");
        }

        static void DemoSimpleRemote()
        {
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("     DEMO 1: Simple Remote Control (One Button)    ");
            Console.WriteLine("═══════════════════════════════════════════════════");

            var remote = new SimpleRemoteControl();
            var light = new Light("Living Room");
            var garageDoor = new GarageDoor("Main");

            Console.WriteLine("\nSetting up: Light On Command");
            remote.Slot = new LightOnCommand(light);
            remote.ButtonWasPressed();

            Console.WriteLine("\nSetting up: Garage Door Open Command");
            remote.Slot = new GarageDoorUpCommand(garageDoor);
            remote.ButtonWasPressed();
        }

        static void DemoStandardRemote()
        {
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("     DEMO 2: Standard Remote Control (7 Slots)     ");
            Console.WriteLine("═══════════════════════════════════════════════════");

            var remote = new RemoteControl(7);

            var livingRoomLight = new Light("Living Room");
            var kitchenLight = new Light("Kitchen");
            var bedroomLight = new Light("Bedroom");
            var ceilingFan = new CeilingFan("Living Room");
            var garageDoor = new GarageDoor("Main");
            var stereo = new Stereo("Living Room");

            remote.SetCommand(0, new LightOnCommand(livingRoomLight), new LightOffCommand(livingRoomLight));
            remote.SetCommand(1, new LightOnCommand(kitchenLight), new LightOffCommand(kitchenLight));
            remote.SetCommand(2, new LightOnCommand(bedroomLight), new LightOffCommand(bedroomLight));
            remote.SetCommand(3, new CeilingFanHighCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));
            remote.SetCommand(4, new GarageDoorUpCommand(garageDoor), new GarageDoorDownCommand(garageDoor));
            remote.SetCommand(5, new StereoOnWithCDCommand(stereo), new StereoOffCommand(stereo));

            Console.WriteLine(remote);

            Console.WriteLine("\nTesting all On buttons:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\n[Slot {i} ON]");
                remote.OnButtonWasPushed(i);
            }

            Console.WriteLine("\n\nTesting all Off buttons:");
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"\n[Slot {i} OFF]");
                remote.OffButtonWasPushed(i);
            }
        }

        static void DemoRemoteWithUndo()
        {
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("  DEMO 3: Remote Control with Undo (Single Level)  ");
            Console.WriteLine("═══════════════════════════════════════════════════");

            var remote = new RemoteControlWithUndo(4);

            var light = new Light("Living Room");
            var ceilingFan = new CeilingFan("Living Room");

            remote.SetCommand(0, new LightOnCommand(light), new LightOffCommand(light));
            remote.SetCommand(1, new CeilingFanLowCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));
            remote.SetCommand(2, new CeilingFanMediumCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));
            remote.SetCommand(3, new CeilingFanHighCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));

            Console.WriteLine(remote);

            Console.WriteLine("\nTurn light ON, then UNDO");
            remote.OnButtonWasPushed(0);
            remote.UndoButtonWasPushed();

            Console.WriteLine("\nTurn light OFF, then UNDO");
            remote.OffButtonWasPushed(0);
            remote.UndoButtonWasPushed();

            Console.WriteLine("\nTesting ceiling fan with single undo:");
            Console.WriteLine("\nSet to LOW");
            remote.OnButtonWasPushed(1);

            Console.WriteLine("\nSet to MEDIUM");
            remote.OnButtonWasPushed(2);

            Console.WriteLine("\nSet to HIGH");
            remote.OnButtonWasPushed(3);

            Console.WriteLine("\nUNDO (only remembers last command: HIGH to MEDIUM)");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\nNOTE: This remote only has single-level undo!");
            Console.WriteLine("   It can only undo the LAST command executed.");
            Console.WriteLine("   For multiple undo levels, see Demo 4.");
        }

        static void DemoRemoteWithMultipleUndos()
        {
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("    DEMO 4: Remote Control with Multiple Undos     ");
            Console.WriteLine("═══════════════════════════════════════════════════");

            var remote = new RemoteControlWithMultipleUndos(3);

            var light = new Light("Living Room");
            var stereo = new Stereo("Living Room");
            var ceilingFan = new CeilingFan("Living Room");

            remote.SetCommand(0, new LightOnCommand(light), new LightOffCommand(light));
            remote.SetCommand(1, new StereoOnWithCDCommand(stereo), new StereoOffCommand(stereo));
            remote.SetCommand(2, new CeilingFanHighCommand(ceilingFan), new CeilingFanOffCommand(ceilingFan));

            Console.WriteLine(remote);

            Console.WriteLine("\nExecute multiple commands:");
            Console.WriteLine("\n[1] Turn light ON");
            remote.OnButtonWasPushed(0);

            Console.WriteLine("\n[2] Turn stereo ON");
            remote.OnButtonWasPushed(1);

            Console.WriteLine("\n[3] Turn ceiling fan ON");
            remote.OnButtonWasPushed(2);

            Console.WriteLine("\n[4] Turn light OFF");
            remote.OffButtonWasPushed(0);

            Console.WriteLine("\n\nNow undo them one by one:");
            Console.WriteLine("\n[Undo 1] Light back ON");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\n[Undo 2] Ceiling fan back OFF");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\n[Undo 3] Stereo back OFF");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\n[Undo 4] Light back OFF");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\n[Undo 5] Nothing to undo - using NoCommand");
            remote.UndoButtonWasPushed();
        }

        static void DemoMacroCommand()
        {
            Console.WriteLine("═══════════════════════════════════════════════════");
            Console.WriteLine("        DEMO 5: Macro Commands - PARTY MODE!       ");
            Console.WriteLine("═══════════════════════════════════════════════════");

            var remote = new RemoteControlWithMultipleUndos(2);

            var light = new Light("Living Room");
            var stereo = new Stereo("Living Room");
            var ceilingFan = new CeilingFan("Living Room");

            var partyOn = new MacroCommand([
                new LightOnCommand(light),
                new StereoOnWithCDCommand(stereo),
                new CeilingFanMediumCommand(ceilingFan)
            ]);

            var partyOff = new MacroCommand([
                new LightOffCommand(light),
                new StereoOffCommand(stereo),
                new CeilingFanOffCommand(ceilingFan)
            ]);

            remote.SetCommand(0, partyOn, partyOff);

            Console.WriteLine("\nPushing PARTY ON Macro:");
            remote.OnButtonWasPushed(0);

            Console.WriteLine("\n\nPushing PARTY OFF Macro:");
            remote.OffButtonWasPushed(0);

            Console.WriteLine("\n\nPushing UNDO (Party back ON!):");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\n\nPushing UNDO again (Party back OFF!):");
            remote.UndoButtonWasPushed();

            Console.WriteLine("\n\nNOTE: Macro commands execute multiple commands at once!");
            Console.WriteLine("   And can undo them all in reverse order.");
        }
    }
}
