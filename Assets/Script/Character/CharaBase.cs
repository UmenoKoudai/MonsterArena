using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

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

    private Vector3 _basePos;
    public Vector3 BasePos { get => _basePos; set => _basePos = value; }

    [SerializeField]
    private float _interval;
    public float Interval => _interval;

    [Tooltip("�L������HP�\��")]
    [SerializeField]
    private Slider _hpBar;
    public Slider HpBar { get => _hpBar; set => _hpBar = value; }


    [Tooltip("�L�����̃X�e�[�^�X")]
    [SerializeField]
    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hpBar.value = value;
            _hp = value;
            if (_hp > _defaultHp) Hp = _defaultHp;
        }
    }

    [SerializeField]
    private int _attack;
    public int Attack { get => _attack; set => _attack = value; }

    [SerializeField]
    private int _defense;
    public int Defense { get => _defense; set => _defense = value; }

    private Rigidbody _rb;
    public Rigidbody Rb
    {
        get => _rb;
        set
        {
            _rb = value;
        }
    }

    private int _defaultHp;
    public int DefaultHp { get => _defaultHp; set => _defaultHp = value; }

    public virtual void Damage(int damage)
    {
        Debug.LogError("Damage�֐����I�[�o�[���C�h���Ă��܂���");
    }

    public virtual void AttackBuff(int value)
    {
        Debug.LogError("AttackBuff�֐����I�[�o�[���C�h���Ă��܂���");
    }

    public virtual void DefenseBuff(int value)
    {
        Debug.LogError("DefenseBuff�֐����I�[�o�[���C�h���Ă��܂���");
    }

    public virtual void Recovery(int value)
    {
        Debug.LogError("Recovery�֐����I�[�o�[���C�h���Ă��܂���");
    }
}