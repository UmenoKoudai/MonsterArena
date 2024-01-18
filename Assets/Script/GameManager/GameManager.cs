using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerTurn _player;

    [SerializeField]
    EnemyTurn _enemy;

    private NowTurn _turn;
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
        Player,
        Enemy,
    }

    private void Awake()
    {
        _player.Init();
        _enemy.Init();
    }

    private void Update()
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
