using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerTurn _player;

    [SerializeField]
    EnemyTurn _enemy;

    private NowTurn _turn = NowTurn.None;
    public NowTurn Turn
    {
        get => _turn;
        set
        {
            _turn = value;
        }
    }

    public enum NowTurn
    {
        None,
        Player,
        Enemy,
    }

    private void Awake()
    {
        _player.Init(this, NowTurn.Enemy);
        _enemy.Init(this, NowTurn.Player);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) TurnChange(NowTurn.Player);
        if (_turn == NowTurn.Player)
        {
            _player.ManualUpdate();
        }
        else
        {
            _enemy.ManualUpdate();
        }
    }

    private void FixedUpdate()
    {
        if(_turn == NowTurn.Player)
        {
            _player.ManualFixedUpdate();
        }
        else
        {
            _enemy.ManualFixedUpdate();
        }
    }

    public void TurnChange(NowTurn changeTurn)
    {
        Turn = changeTurn;
    }
}
