public class PlayerTurn : TurnBase
{
    /// <summary>������</summary>
    /// <param name="gameManager"></param>
    /// <param name="changeTurn"></param>
    public void Init(GameManager gameManager, GameManager.NowTurn changeTurn)
    {
        Build(gameManager, changeTurn, SelectCard.Turn.Player);
    }

    protected override void Enter()
    {
        PlayerCamera.Priority = 10;
        EnemyCamera.Priority = 0;
    }

    /// <summary>�X�e�[�g��ς���</summary>
    /// <param name="change"></param>
    public override void StateChange(Phase change)
    {
        NowPhase = change;
    }
}
