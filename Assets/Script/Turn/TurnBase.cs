using UnityEngine;
using UnityEngine.UI;

public class TurnBase : MonoBehaviour
{
    [SerializeField]
    private CharaBase _character;
    public CharaBase Character => _character;

    [SerializeField]
    private GameObject SelectPanel;

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

    [SerializeField]
    private int _angle;
    public int Angle => _angle;

    public enum Phase
    {
        Stand,
        Select,
        Move,
        Attack,
        EntTurn,
    }

    public virtual void StateChange(Phase change)
    {
        Debug.LogError("オーバーライドしていません");
    }
}