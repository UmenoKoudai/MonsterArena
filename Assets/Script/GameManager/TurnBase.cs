using UnityEngine;
using UnityEngine.UI;

public class TurnBase : MonoBehaviour
{
    [SerializeField]
    private GameObject SelectPanel;

    [SerializeField]
    private int _hp;
    public int HP
    {
        get => _hp;
        set
        {
            _hp = value;
        }
    }

    [SerializeField]
    private int _defense;
    public int Defense
    {
        get => _defense;
        set
        {
            _defense = value;
        }
    }

    [SerializeField]
    private int _attack;
    public int Attack
    {
        get => _attack;
        set
        {
            _attack = value;
        }
    }

    [SerializeField]
    private SelectCard _selectCard;
    public SelectCard SelectCardScript => _selectCard;

    [SerializeField]
    private SelectTimer _selectTimer;
    public SelectTimer SelectTimer => _selectTimer;

    [SerializeField]
    private Image _standByField;
    public Image StandByField => _standByField;

    [SerializeField]
    private Image _attackField;
    public Image AttackField => _attackField;

    [SerializeField]
    private GameObject[] _selectObject;
    public GameObject[] SelectObject => _selectObject;

    public enum Phase
    {
        Stand,
        Select,
        Attack,
        EntTurn,
    }

    public virtual void StateChange(Phase change)
    {
        Debug.LogError("オーバーライドしていません");
    }
}