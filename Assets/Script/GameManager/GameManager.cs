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
            if (_turn == NowTurn.Player)
            {
                FieldData.Instance.Target = FieldData.Instance.Enemy;
                FieldData.Instance.Attacker = FieldData.Instance.Player;
            }
            else if (_turn == NowTurn.Enemy)
            {
                FieldData.Instance.Target = FieldData.Instance.Player;
                FieldData.Instance.Attacker = FieldData.Instance.Enemy;
            }
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
        if (_turn == NowTurn.Player)
        {
            FieldData.Instance.Target = FieldData.Instance.Enemy;
            FieldData.Instance.Attacker = FieldData.Instance.Player;
        }
        else
        {
            FieldData.Instance.Target = FieldData.Instance.Player;
            FieldData.Instance.Attacker = FieldData.Instance.Enemy;
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) TurnChange(NowTurn.Player);
        if (_turn == NowTurn.Player)
        {
            _player.ManualUpdate();
        }
        else if(_turn == NowTurn.Enemy)
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
        else if (_turn == NowTurn.Enemy)
        {
            _enemy.ManualFixedUpdate();
        }
    }

    public void TurnChange(NowTurn changeTurn)
    {
        Turn = changeTurn;
    }
}
