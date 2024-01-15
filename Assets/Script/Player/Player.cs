using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField]
    private Animator _animl;
    public Animator Anim => _animl;
    [Header("プレイヤーの動きに関する数値")]
    [SerializeField]
    private float  _speed = 5f;
    public float Speed => _speed;
    [SerializeField]
    private Transform _movePos;
    public Transform MovePos => _movePos;

    private  PlayerMoveState _move;
    private PlayerAttackState _attack;

    private Rigidbody _rb;
    public Rigidbody Rb
    {
        get => _rb;
        set
        {
            _rb = value;
        }
    }
    private PlayerState _state = PlayerState.Move;
    public PlayerState State
    {
        get => _state;
        set
        {
            if (_state == value) return;
            _state = value;
            switch (_state)
            {
                case PlayerState.Move:
                    _move.Enter();
                    break;
                case PlayerState.Attack:
                    _attack.Enter();
                    break;
            }
        }
    }
    private Vector3 _direction;
    public Vector3 Direction => _direction;


    public enum PlayerState
    {
        Move,
        Attack,
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _move = new PlayerMoveState(this);
        _attack = new PlayerAttackState(this);
    }

    private void Update()
    {
        switch (_state)
        {
            case PlayerState.Move:
                _move.Update();
                break;
            case PlayerState.Attack:
                _attack.Update();
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (_state)
        {
            case PlayerState.Move:
                _move.FixedUpdate();
                break;
        }
    }

    public void StateChange(PlayerState state)
    {
        State = state;
    }
}

