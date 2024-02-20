public class Stand : IStateMachine
{
    TurnBase _turnBase;
    public Stand(TurnBase turnBase)
    {
        _turnBase = turnBase;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _turnBase.StateChange(TurnBase.Phase.Select);
    }
}
