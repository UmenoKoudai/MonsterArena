using UnityEngine;
using UnityEngine.UI;
using static GameManager;

public class CharaBase : MonoBehaviour
{
    [SerializeField]
    private Animator _animl;
    public Animator Anim => _animl;

    [Header("プレイヤーの動きに関する数値")]
    [SerializeField]
    [Min(20)]
    private float _speed = 20f;
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
    [Min(45)]
    private int _angle = 45;
    public int Angle => _angle;

    [Tooltip("キャラのHP表示")]
    [SerializeField]
    private Slider _hpBar;
    public Slider HpBar { get => _hpBar; set => _hpBar = value; }


    [Tooltip("キャラのステータス")]
    [SerializeField]
    private int _hp;
    public int Hp
    {
        get => _hp;
        set
        {
            _hpBar.value = _defaultHp - value;
            _hp = value;
            if (_hp < 0) FindObjectOfType<GameManager>().TurnChange(NowTurn.GameEnd);
            if (_hp > _defaultHp) Hp = _defaultHp;
        }
    }

    [SerializeField]
    private int _attack;
    public int Attack { get => _attack; set => _attack = value; }

    [SerializeField]
    private int _defense;
    public int Defense { get => _defense; set => _defense = value; }

    [SerializeField]
    private ParticleSystem _attackBuffParticle;
    public ParticleSystem AttackBuffParticle => _attackBuffParticle;

    [SerializeField]
    private ParticleSystem _defenseBuffParticle;
    public ParticleSystem DefenseBuffParticle => _defenseBuffParticle;

    [SerializeField]
    private ParticleSystem _recoveryParticle;
    public ParticleSystem RecoveryParticle => _recoveryParticle;

    [SerializeField]
    private ParticleSystem[] _damageParticle;
    public ParticleSystem[] DamageParticle => _damageParticle;

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
        Debug.LogError("Damage関数をオーバーライドしていません");
    }

    public virtual void AttackBuff(int value)
    {
        Debug.LogError("AttackBuff関数をオーバーライドしていません");
    }

    public virtual void DefenseBuff(int value)
    {
        Debug.LogError("DefenseBuff関数をオーバーライドしていません");
    }

    public virtual void Recovery(int value)
    {
        Debug.LogError("Recovery関数をオーバーライドしていません");
    }
}
