using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// ターンが切り替わった時に最初に呼ばれるステート
/// </summary>
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
        Exit();
    }

    public void Exit()
    {
        _turnBase.StateChange(TurnBase.Phase.Select);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _turnBase.StateChange(TurnBase.Phase.Select);
    }
}
