using Cinemachine;
using DG.Tweening.Core.Easing;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TurnBase : MonoBehaviour
{
    [SerializeField, Tooltip("動かすモデル(プレイヤーかエネミー)")]
    private CharaBase _character;
    public CharaBase Character => _character;

    [SerializeField, Tooltip("セレクトフェーズで選んだカードを置いておく場所")]
    private GameObject SelectPanel;

    [SerializeField, Tooltip("セレクトフェーズの機能")]
    private SelectCard _selectCard;
    public SelectCard SelectCardScript => _selectCard;

    [SerializeField, Tooltip("セレクトフェーズの時間")]
    private SelectTimer _selectTimer;
    public SelectTimer SelectTimer => _selectTimer;

    [SerializeField, Tooltip("攻撃予定のカードをおいている場所")]
    private Image _standByField;
    public Image StandByField => _standByField;

    [SerializeField, Tooltip("今攻撃しているカードを置く場所")]
    private Image _attackField;
    public Image AttackField => _attackField;

    [SerializeField, Tooltip("セレクト画面のイメージ")]
    private GameObject[] _selectObject;
    public GameObject[] SelectObject => _selectObject;

    [SerializeField, Tooltip("今のターンを表示させるアニメーション")]
    private Animator _phaseAnimator;
    public Animator PhaseAnimator => _phaseAnimator;

    [Header("キャラ毎のカメラ")]
    [SerializeField, Tooltip("プレイヤーを注目するカメラ")]
    private CinemachineVirtualCamera _playerCamera;
    public CinemachineVirtualCamera PlayerCamera => _playerCamera;

    [SerializeField, Tooltip("エネミーを注目するカメラ")]
    private CinemachineVirtualCamera _enemyCamera;
    public CinemachineVirtualCamera EnemyCamera => _enemyCamera;

    //バフや回復等の特殊な効果
    private List<IAbility> _specialAbility = new List<IAbility>();
    public List<IAbility> SpecialAbility => _specialAbility;

    public enum Phase
    {
        Stand,
        Select,
        AttackStart,
        Attack,
        AttackEnd,
        EndTurn,

        MaxPhase,
    }


    protected Phase _phase = Phase.EndTurn;
    public Phase NowPhase
    {
        get => _phase;
        set
        {
            if (_phase == value) return;
            _phase = value;
            _currentState = _states[(int)_phase];
            _currentState.Enter();
            Enter();
        }
    }

    protected IStateMachine _currentState;
    protected IStateMachine[] _states = new IStateMachine[(int)Phase.MaxPhase];

    public virtual void StateChange(Phase change)
    {
        Debug.LogError("オーバーライドしていません");
    }

    protected virtual void Enter()
    {
        
    }

    public virtual void Build()
    {
        _states[(int)Phase.Stand] = new Stand(this);

        _stand = new Stand(this);
        _select = new Select(this, SelectCard.Turn.Player);
        _attackStart = new AttackStart(this);
        _attack = new Attack(this);
        _attackEnd = new AttackEnd(this);
        _endTurn = new EndTurn(gameManager, changeTurn, this);
    }

    public void ManualUpdate()
    {
        _state.Update();
    }
}