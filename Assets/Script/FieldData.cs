using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 盤面の情報を管理するクラス
/// </summary>
public class FieldData : MonoBehaviour
{
    private static FieldData _instance;
    public static FieldData Instance
    {
        get
        {
            if(_instance == null) _instance = FindObjectOfType<FieldData>();
            if (_instance == null) Debug.LogError("FieldDataが存在しません。");
            return _instance;
        }
    }

    private Player _player;
    public Player Player { get => _player; set => _player = value; }
    private Enemy _enemy;
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    /// <summary>
    /// 攻撃やカード効果を発動する相手を￥保管する変数
    /// </summary>
    private CharaBase _target;
    public CharaBase Target { get => _target; set => _target = value; }
    /// <summary>
    /// アタックしているキャラを格納する変数
    /// </summary>
    private CharaBase _attacker;
    public CharaBase Attacker { get => _attacker; set => _attacker = value; }
    /// <summary>
    /// 選択したカードを保管する変数
    /// </summary>
    private Queue<Card> _selectCard = new Queue<Card>();
    public Queue<Card> SelectCard {  get => _selectCard; set => _selectCard = value; }
    /// <summary>
    /// ひとつ前に選択したカードの優先度を保管する変数
    /// </summary>
    private int _priority = 0;
    public int Priority { get => _priority; set => _priority = value; }

    public void DestroyObject(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.transform.position = new Vector3(-999, -999, -999);
    }
}
