using Cysharp.Threading.Tasks;
using System;

public class EndTurn : IStateMachine
{
    private GameManager _gameManager;
    private TurnBase _turnBase;
    private GameManager.NowTurn _changeTurn;
    private CharaBase _character;

    public EndTurn(GameManager gameManager, GameManager.NowTurn change, TurnBase turnBase)
    {
        _turnBase = turnBase;
        _gameManager = gameManager;
        _changeTurn = change;
        _character = _turnBase.Character;
    }

    public async void Enter()
    {
        _turnBase.PhaseAnimator.Play("End");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
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
