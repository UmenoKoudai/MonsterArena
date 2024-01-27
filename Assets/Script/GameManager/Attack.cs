using UnityEngine;

public class Attack : IStateMachine
{
    PlayerTurn _player;
    EnemyTurn _enemy;
    public void Init(PlayerTurn player = null, EnemyTurn enemy = null)
    {
        if (!(player is null)) _player = player;
        if(!(enemy is null)) _enemy = enemy;
    }

    public void Enter()
    {
        Debug.Log("Attack");
        _player?.StateChange(PlayerTurn.Phase.EntTurn);
        _enemy?.StateChange(EnemyTurn.Phase.EntTurn);
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
