using UnityEngine;
using UnityEngine.UI;

public class CharaBase : MonoBehaviour
{
    [SerializeField]
    private Animator _animl;
    public Animator Anim => _animl;

    [Header("プレイヤーの動きに関する数値")]
    [SerializeField]
    private float _speed = 5f;
    public float Speed => _speed;

    [SerializeField]
    private Transform _movePos;
    public Transform MovePos => _movePos;

    private Vector3 _basePos;
    public Vector3 BasePos { get => _basePos; set => _basePos = value; }

    [SerializeField]
    private float _interval;
    public float Interval => _interval;

    [SerializeField]
    private Slider _hpBar;
    public Slider HpBar { get => _hpBar; set => _hpBar = value; }

    private Rigidbody _rb;
    public Rigidbody Rb
    {
        get => _rb;
        set
        {
            _rb = value;
        }
    }
}
