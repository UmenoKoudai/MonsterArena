using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnBase : MonoBehaviour
{
    [SerializeField, Tooltip("���������f��(�v���C���[���G�l�~�[)")]
    private CharaBase _character;
    public CharaBase Character => _character;

    [SerializeField, Tooltip("�Z���N�g�t�F�[�Y�őI�񂾃J�[�h��u���Ă����ꏊ")]
    private GameObject SelectPanel;

    [SerializeField, Tooltip("�Z���N�g�t�F�[�Y�̋@�\")]
    private SelectCard _selectCard;
    public SelectCard SelectCardScript => _selectCard;

    [SerializeField, Tooltip("�Z���N�g�t�F�[�Y�̎���")]
    private SelectTimer _selectTimer;
    public SelectTimer SelectTimer => _selectTimer;

    [SerializeField, Tooltip("�U���\��̃J�[�h�������Ă���ꏊ")]
    private Image _standByField;
    public Image StandByField => _standByField;

    [SerializeField, Tooltip("���U�����Ă���J�[�h��u���ꏊ")]
    private Image _attackField;
    public Image AttackField => _attackField;

    [SerializeField, Tooltip("�Z���N�g��ʂ̃C���[�W")]
    private GameObject[] _selectObject;
    public GameObject[] SelectObject => _selectObject;

    [SerializeField, Tooltip("���̃^�[����\��������A�j���[�V����")]
    private Animator _phaseAnimator;
    public Animator PhaseAnimator => _phaseAnimator;

    [Header("�L�������̃J����")]
    [SerializeField, Tooltip("�v���C���[�𒍖ڂ���J����")]
    private CinemachineVirtualCamera _playerCamera;
    public CinemachineVirtualCamera PlayerCamera => _playerCamera;

    [SerializeField, Tooltip("�G�l�~�[�𒍖ڂ���J����")]
    private CinemachineVirtualCamera _enemyCamera;
    public CinemachineVirtualCamera EnemyCamera => _enemyCamera;

    //�o�t��񕜓��̓���Ȍ���
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


    public virtual void Build(GameManager gameManager, GameManager.NowTurn changeTurn, SelectCard.Turn select)
    {
        _states[(int)Phase.Stand] = new Stand(this);
        _states[(int)Phase.Select] = new Select(this, select);
        _states[(int)Phase.AttackStart] = new AttackStart(this);
        _states[(int)Phase.Attack] = new Attack(this);
        _states[(int)Phase.AttackEnd] = new AttackEnd(this);
        _states[(int)Phase.EndTurn] = new EndTurn(gameManager, changeTurn, this);
    }

    public void ManualUpdate()
    {
        _currentState.Update();
    }

    public void ManualFixedUpdate()
    {
        _currentState.FixedUpdate();
    }

    public void SelectSkip()
    {
        if (_phase == Phase.Select)
            _currentState.Exit();
    }

    public virtual void StateChange(Phase change)
    {
        Debug.LogError("StateChange�֐��̓I�[�o�[���C�h���Ă��܂���");
    }

    protected virtual void Enter()
    {
        Debug.LogError("Enter�֐��̓I�[�o���C�h���Ă��܂���");
    }
}