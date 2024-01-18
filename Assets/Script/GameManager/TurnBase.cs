using UnityEngine;

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
    public SelectCard SelectCardScript
    {
        get => _selectCard;
    }
}