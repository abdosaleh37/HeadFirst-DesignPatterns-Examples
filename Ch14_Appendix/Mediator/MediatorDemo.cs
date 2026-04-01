namespace Ch14_Appendix.Mediator;

public static class MediatorDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Mediator Pattern ---");

        var chat = new ChatRoom();
        var alice = new Participant("Alice", chat);
        var bob = new Participant("Bob", chat);
        var clara = new Participant("Clara", chat);

        chat.Register(alice);
        chat.Register(bob);
        chat.Register(clara);

        alice.Send("Hello team!");
        bob.Send("Hi Alice, sprint update is ready.");
    }
}
