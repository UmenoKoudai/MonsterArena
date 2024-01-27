using UnityEngine;

public class Stand : IStateMachine
{
    PlayerTurn _player;
    EnemyTurn _enemy;
    public void Init(PlayerTurn player = null, EnemyTurn enemy = null)
    {
        if(!(player is null)) _player = player;
        if(!(enemy is null)) _enemy = enemy;
        Debug.Log($"Player:{ _player is null}");
    }

    public void Enter()
    {
        _player?.StateChange(PlayerTurn.Phase.Select);
        _enemy?.StateChange(EnemyTurn.Phase.Select);
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _player?.StateChange(PlayerTurn.Phase.Select);
    }
}
