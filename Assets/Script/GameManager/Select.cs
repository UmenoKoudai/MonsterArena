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
        Debug.Log("セレクトフェーズ");
        if(_isPlayer)
        {
            _player.SelectCardScript.gameObject.SetActive(true);
            if (_player.SelectCardScript is null) Debug.Log("nullだよ");
            _player.SelectCardScript.Init();
            await _player.SelectTimer.Init();
            _player.StateChange(PlayerTurn.Phase.Attack);
        }
        else
        {
            _enemy.SelectCardScript.gameObject?.SetActive(true);
            _enemy.SelectCardScript.Init();
            await _enemy.SelectTimer.Init();
            _enemy.StateChange(EnemyTurn.Phase.Attack);
        }
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
