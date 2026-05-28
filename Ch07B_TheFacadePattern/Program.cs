using Ch07B_TheFacadePattern.Components;
using Ch07B_TheFacadePattern.Facades;

namespace Ch07B_TheFacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintSection("Chapter 7B - Facade Pattern");

            Amplifier amp = new Amplifier();
            Tuner tuner = new Tuner(amp);
            StreamingPlayer player = new StreamingPlayer(amp);
            Projector projector = new Projector(player);
            TheaterLights lights = new TheaterLights();
            Screen screen = new Screen();
            PopcornPopper popper = new PopcornPopper();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(
                amp, tuner, player, projector, lights, screen, popper);

            PrintSection("Movie night");
            homeTheater.WatchMovie("Raiders of the Lost Ark");
            Console.WriteLine();
            homeTheater.EndMovie();

            PrintSection("Radio time");
            homeTheater.ListenToRadio(88.1);
            Console.WriteLine();
            homeTheater.EndRadio();
        }

        static void PrintSection(string title)
        {
            Console.WriteLine();
            Console.WriteLine(new string('-', 60));
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 60));
        }
    }
}
