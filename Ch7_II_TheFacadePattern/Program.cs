using Ch7_II_TheFacadePattern.Components;
using Ch7_II_TheFacadePattern.Facades;

namespace Ch7_II_TheFacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Amplifier amp = new Amplifier();
            Tuner tuner = new Tuner(amp);
            StreamingPlayer player = new StreamingPlayer(amp);
            Projector projector = new Projector(player);
            TheaterLights lights = new TheaterLights();
            Screen screen = new Screen();
            PopcornPopper popper = new PopcornPopper();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(
                amp, tuner, player, projector, lights, screen, popper);

            homeTheater.WatchMovie("Raiders of the Lost Ark");
            Console.WriteLine();
            homeTheater.EndMovie();
            Console.WriteLine();
            homeTheater.ListenToRadio(88.1);
            Console.WriteLine();
            homeTheater.EndRadio();
        }
    }
}
