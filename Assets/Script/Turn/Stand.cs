using Cysharp.Threading.Tasks;
using System;

public class Stand : IStateMachine
{
    TurnBase _turnBase;
    public Stand(TurnBase turnBase)
    {
        _turnBase = turnBase;
    }

    public async void Enter()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        _turnBase.StateChange(TurnBase.Phase.Select);
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        //_turnBase.StateChange(TurnBase.Phase.Select);
    }
}
