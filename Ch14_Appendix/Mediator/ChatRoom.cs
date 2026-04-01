namespace Ch14_Appendix.Mediator;

public sealed class ChatRoom : IChatMediator
{
    private readonly List<Participant> _participants = new();

    public void Register(Participant participant)
    {
        _participants.Add(participant);
    }

    public void Broadcast(string sender, string message)
    {
        foreach (Participant participant in _participants.Where(p => p.Name != sender))
        {
            participant.Receive(sender, message);
        }
    }
}
