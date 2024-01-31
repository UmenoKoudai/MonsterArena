using Cysharp.Threading.Tasks;
using System;

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

    public async void Update()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        _turnBase.StateChange(TurnBase.Phase.Select);
    }
}
