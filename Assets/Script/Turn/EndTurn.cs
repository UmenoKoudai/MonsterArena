using Cysharp.Threading.Tasks;
using System;

public class EndTurn : IStateMachine
{
    private GameManager _gameManager;
    private TurnBase _turnBase;
    private GameManager.NowTurn _changeTurn;

    public EndTurn(GameManager gameManager, GameManager.NowTurn change, TurnBase turnBase)
    {
        _turnBase = turnBase;
        _gameManager = gameManager;
        _changeTurn = change;
    }

    public async void Enter()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(2));
        _gameManager.TurnChange(_changeTurn);
        _turnBase.StateChange(TurnBase.Phase.Stand);
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
