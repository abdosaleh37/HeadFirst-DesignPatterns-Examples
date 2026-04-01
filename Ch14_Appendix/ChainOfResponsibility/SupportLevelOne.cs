namespace Ch14_Appendix.ChainOfResponsibility;

public sealed class SupportLevelOne : SupportHandler
{
    protected override bool TryHandle(SupportTicket ticket)
    {
        if (ticket.Severity != 1)
        {
            return false;
        }

        Console.WriteLine($"L1 solved: {ticket.Description}");
        return true;
    }
}
