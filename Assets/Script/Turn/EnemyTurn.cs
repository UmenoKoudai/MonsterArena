public class EnemyTurn : TurnBase
{
    public void Init(GameManager gameManager, GameManager.NowTurn changeTurn)
    {
        Build(gameManager, changeTurn, SelectCard.Turn.Enemy);
        //StateChange(Phase.Stand);
    }

    protected override void Enter()
    {
        PlayerCamera.Priority = 0;
        EnemyCamera.Priority = 10;
    }

    public override void StateChange(Phase change)
    {
        NowPhase = change;
    }
}
