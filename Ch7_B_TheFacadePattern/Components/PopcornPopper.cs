namespace Ch7_B_TheFacadePattern.Components
{
    public class PopcornPopper
    {
        public void On() => Console.WriteLine("Popcorn Popper on");

        public void Off() => Console.WriteLine("Popcorn Popper off");

        public void Pop() => Console.WriteLine("Popcorn Popper popping popcorn!");

        public override string ToString() => "Popcorn Popper";
    }
}
