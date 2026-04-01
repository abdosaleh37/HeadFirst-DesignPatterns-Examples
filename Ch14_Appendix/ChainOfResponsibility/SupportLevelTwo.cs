namespace Ch14_Appendix.ChainOfResponsibility;

public sealed class SupportLevelTwo : SupportHandler
{
    protected override bool TryHandle(SupportTicket ticket)
    {
        if (ticket.Severity != 2)
        {
            return false;
        }

        Console.WriteLine($"L2 solved: {ticket.Description}");
        return true;
    }
}
