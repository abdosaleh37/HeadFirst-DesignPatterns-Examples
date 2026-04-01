namespace Ch14_Appendix.ChainOfResponsibility;

public abstract class SupportHandler
{
    private SupportHandler? _next;

    public SupportHandler SetNext(SupportHandler next)
    {
        _next = next;
        return next;
    }

    public void Handle(SupportTicket ticket)
    {
        if (!TryHandle(ticket) && _next is not null)
        {
            _next.Handle(ticket);
        }
    }

    protected abstract bool TryHandle(SupportTicket ticket);
}
