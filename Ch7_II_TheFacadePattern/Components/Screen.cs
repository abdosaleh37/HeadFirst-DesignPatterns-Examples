namespace Ch7_II_TheFacadePattern.Components
{
    public class Screen
    {
        public void Up() => Console.WriteLine("Theater Screen going up");

        public void Down() => Console.WriteLine("Theater Screen going down");

        public override string ToString() => "Theater Screen";
    }
}
