using UnityEngine;

public class CharaBase : MonoBehaviour
{
    [SerializeField]
    private Animator _animl;
    public Animator Anim => _animl;
    [Header("�v���C���[�̓����Ɋւ��鐔�l")]
    [SerializeField]
    private float _speed = 5f;
    public float Speed => _speed;
    [SerializeField]
    private Transform _movePos;
    public Transform MovePos => _movePos;
    [SerializeField]
    private float _interval;
    public float Interval => _interval;

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
