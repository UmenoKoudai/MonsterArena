using System.Collections;
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
            if (_instance == null) Debug.LogError("FieldDataÇ™ë∂ç›ÇµÇ‹ÇπÇÒÅB");
            return _instance;
        }
    }

    public PlayerTurn PlayerTurn;
    public EnemyTurn EnemyTurn;
    public Player Player;
    public Enemy Enemy;
}
