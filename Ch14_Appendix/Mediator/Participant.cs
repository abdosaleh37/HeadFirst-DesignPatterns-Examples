namespace Ch14_Appendix.Mediator;

public sealed class Participant
{
    private readonly IChatMediator _mediator;

    public Participant(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public string Name { get; }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sends: {message}");
        _mediator.Broadcast(Name, message);
    }

    public void Receive(string sender, string message)
    {
        Console.WriteLine($"{Name} received from {sender}: {message}");
    }
}
