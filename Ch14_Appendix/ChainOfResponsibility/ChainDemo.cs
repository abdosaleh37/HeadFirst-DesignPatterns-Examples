namespace Ch14_Appendix.ChainOfResponsibility;

public static class ChainDemo
{
    public static void Run()
    {
        Console.WriteLine();
        Console.WriteLine("--- Chain of Responsibility Pattern ---");

        var low = new SupportLevelOne();
        var mid = new SupportLevelTwo();
        var high = new SupportManager();

        low.SetNext(mid).SetNext(high);

        low.Handle(new SupportTicket("Password reset", 1));
        low.Handle(new SupportTicket("Billing mismatch", 2));
        low.Handle(new SupportTicket("Service outage", 3));
    }
}
