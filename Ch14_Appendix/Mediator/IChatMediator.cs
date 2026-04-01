namespace Ch14_Appendix.Mediator;

public interface IChatMediator
{
    void Register(Participant participant);
    void Broadcast(string sender, string message);
}
