using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("プレイヤーの動きに関する数値")]
    [SerializeField]
    float _speed = 5f;
    public float Speed => _speed;
    [Header("プレイヤーの攻撃に関する数値")]
    float _power = 1f;
    public float Power => _power;

    PlayerMoveState _move;
    PlayerAttackState _attack;

    Rigidbody _rb;
    public Rigidbody Rb
    {
        get => _rb;
        set
        {
            _rb = value;
        }
    }
    PlayerState _state = PlayerState.Move;
    public PlayerState State
    {
        get => _state;
        set
        {
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
    Vector3 _direction;
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

    private void Start()
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
            case PlayerState.Attack:
                _attack.FixedUpdate();
                break;
        }
    }

    public void OnMove(InputAction.CallbackContext callback)
    {
        var dir = callback.ReadValue<Vector2>();
        _direction = new Vector3(dir.x, 0, dir.y);
    }
}

