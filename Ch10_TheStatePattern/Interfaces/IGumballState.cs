namespace Ch10_TheStatePattern.Interfaces;

public interface IGumballState
{
    void InsertQuarter();
    void EjectQuarter();
    void TurnCrank();
    void Dispense();
}
