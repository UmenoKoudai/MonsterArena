using System.Collections.Generic;
using UnityEngine;

public class FieldData : MonoBehaviour
{
    private static FieldData _instance;
    public static FieldData Instance
    {
        get
        {
            if(_instance == null) _instance = FindObjectOfType<FieldData>();
            if (_instance == null) Debug.LogError("FieldData‚ª‘¶Ý‚µ‚Ü‚¹‚ñB");
            return _instance;
        }
    }

    private Player _player;
    public Player Player { get => _player; set => _player = value; }
    private Enemy _enemy;
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    private CharaBase _target;
    public CharaBase Target { get => _target; set => _target = value; }
    private CharaBase _attacker;
    public CharaBase Attacker { get => _attacker; set => _attacker = value; }
    private Queue<Card> _selectCard = new Queue<Card>();
    public Queue<Card> SelectCard {  get => _selectCard; set => _selectCard = value; }
    private int _priority = 0;
    public int Priority { get => _priority; set => _priority = value; }

    public void DestroyObject(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.transform.position = new Vector3(-999, -999, -999);
    }
}
