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

    private PlayerTurn _playerTurn;
    public PlayerTurn PlayerTurn { get => _playerTurn; set => _playerTurn = value; }
    private EnemyTurn _enemyTurn;
    public EnemyTurn EnemyTurn { get => _enemyTurn; set => _enemyTurn = value; }
    private Player _player;
    public Player Player { get => _player; set => _player = value; }
    private Enemy _enemy;
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    private Queue<Card> _selectCard = new Queue<Card>();
    public Queue<Card> SelectCard {  get => _selectCard; set => _selectCard = value; }
    private int _priority = 0;
    public int Priority { get => _priority; set => _priority = value; }

    public void DestroyObject(GameObject obj)
    {
        obj.transform.position = new Vector3(0, 0, -100);
    }
}
