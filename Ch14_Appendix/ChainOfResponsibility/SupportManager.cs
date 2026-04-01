namespace Ch14_Appendix.ChainOfResponsibility;

public sealed class SupportManager : SupportHandler
{
    protected override bool TryHandle(SupportTicket ticket)
    {
        Console.WriteLine($"Manager solved: {ticket.Description}");
        return true;
    }
}
