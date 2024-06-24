using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    PlayerTurn _player;

    [SerializeField]
    EnemyTurn _enemy;

    private ResultState _result;

    public float SelectTimer { get; set; }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    //ƒLƒƒƒ‰‚Ìƒ^[ƒ“‚ªØ‚è‘Ö‚í‚Á‚½Žž‚ÉŒø‰Ê‚Ì‘ÎÛ‚ðØ‚è‘Ö‚¦‚é
    private NowTurn _turn = NowTurn.None;
    public NowTurn Turn
    {
        get => _turn;
        set
        {
            _turn = value;
            if (_turn == NowTurn.Player)
            {
                _player.StateChange(TurnBase.Phase.Stand);
                FieldData.Instance.Target = FieldData.Instance.Enemy;
                FieldData.Instance.Attacker = FieldData.Instance.Player;
            }
            else if (_turn == NowTurn.Enemy)
            {
                _enemy.StateChange(TurnBase.Phase.Stand);
                FieldData.Instance.Target = FieldData.Instance.Player;
                FieldData.Instance.Attacker = FieldData.Instance.Enemy;
            }
            else if(_turn == NowTurn.GameEnd)
            {
                Time.timeScale = 0.5f;
                if(_result == ResultState.Player)
                {
                    SceneLoader.SceneChange("ResultPlayer");
                    Debug.Log("PlayerWin");
                }
                else if(_result == ResultState.Enemy)
                {
                    SceneLoader.SceneChange("ResultEnemy");
                    Debug.Log("EnemyWin");
                }
                else
                {
                    SceneLoader.SceneChange("ResultDraw");
                    Debug.Log("Draw");
                }
            }
        }
    }

    public enum NowTurn
    {
        None,
        Player,
        Enemy,
        GameEnd,
    }

    public enum ResultState
    {
        Player,
        Enemy,
        Draw,
    }

    private void Awake()
    {
        _player.Init(this, NowTurn.Enemy);
        _enemy.Init(this, NowTurn.Player);
        TurnChange(NowTurn.Player);
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
        Debug.Log($"NowTurn{_turn}");
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

    public void StateCheck()
    {
        if(_player.Character.Hp < 0 && _enemy.Character.Hp < 0)
        {
            _result = ResultState.Draw;
            TurnChange(NowTurn.GameEnd);
        }
        else if(_player.Character.Hp < 0)
        {
            _result = ResultState.Enemy;
            TurnChange(NowTurn.GameEnd);
        }
        else if(_enemy.Character.Hp < 0)
        {
            _result = ResultState.Player;
            TurnChange(NowTurn.GameEnd);
        }
    }
}
