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
        await BackStep.BasePositionMove(_character.BasePos, _character.transform, _character.Angle, _character);
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
