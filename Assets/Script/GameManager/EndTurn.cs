public class EndTurn : IStateMachine
{
    private GameManager _gameManager;
    private PlayerTurn _player;
    private EnemyTurn _enemy;
    GameManager.NowTurn _changeTurn;
    public void Init(GameManager gameManager, GameManager.NowTurn change, PlayerTurn playerTurn = null, EnemyTurn enemyTurn = null)
    {
        if(playerTurn != null) _player = playerTurn;
        if(enemyTurn != null) _enemy = enemyTurn;
        _gameManager = gameManager;
        _changeTurn = change;
    }

    public void Enter()
    {
        _gameManager.TurnChange(_changeTurn);
        if (!(_player is null)) _player.StateChange(PlayerTurn.Phase.Stand);
        else _enemy.StateChange(EnemyTurn.Phase.Stand);
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
