using UnityEngine;

public class Select : IStateMachine
{
    private PlayerTurn _player;
    private EnemyTurn _enemy;
    private bool _isPlayer = false;

    public void Init(PlayerTurn player = null, EnemyTurn enemy = null)
    {
        if (!(player is null)) _player = player;
        if(!(enemy is null)) _enemy = enemy;
        if(!(_player is null)) _isPlayer = true;
    }

    public async void Enter()
    {
        if(_isPlayer)
        {
            _player.SelectCardScript.gameObject.SetActive(true);
            _player.SelectCardScript.Init(SelectCard.Turn.Player);
            await _player.SelectTimer.Init();
            Exit();
            _player.StateChange(PlayerTurn.Phase.Attack);
        }
        else
        {
            _enemy.SelectCardScript.gameObject?.SetActive(true);
            _enemy.SelectCardScript.Init(SelectCard.Turn.Enemy);
            await _enemy.SelectTimer.Init();
            Exit();
            _enemy.StateChange(EnemyTurn.Phase.Attack);
        }
    }

    public void Exit()
    {
        if(!(_player is null)) _player.SelectCardScript?.gameObject?.SetActive(false);
        else _enemy.SelectCardScript?.gameObject?.SetActive(false);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        if (_isPlayer) _player.SelectCardScript.ManualUpdate(SelectCard.Turn.Player);
        else _enemy.SelectCardScript.ManualUpdate(SelectCard.Turn.Enemy);
    }
}
