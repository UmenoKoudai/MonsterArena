using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ֆʂ̏����Ǘ�����N���X
/// </summary>
public class FieldData : MonoBehaviour
{
    private static FieldData _instance;
    public static FieldData Instance
    {
        get
        {
            if(_instance == null) _instance = FindObjectOfType<FieldData>();
            if (_instance == null) Debug.LogError("FieldData�����݂��܂���B");
            return _instance;
        }
    }

    private Player _player;
    public Player Player { get => _player; set => _player = value; }
    private Enemy _enemy;
    public Enemy Enemy { get => _enemy; set => _enemy = value; }
    /// <summary>
    /// �U����J�[�h���ʂ𔭓����鑊������ۊǂ���ϐ�
    /// </summary>
    private CharaBase _target;
    public CharaBase Target { get => _target; set => _target = value; }
    /// <summary>
    /// �A�^�b�N���Ă���L�������i�[����ϐ�
    /// </summary>
    private CharaBase _attacker;
    public CharaBase Attacker { get => _attacker; set => _attacker = value; }
    /// <summary>
    /// �I�������J�[�h��ۊǂ���ϐ�
    /// </summary>
    private Queue<Card> _selectCard = new Queue<Card>();
    public Queue<Card> SelectCard {  get => _selectCard; set => _selectCard = value; }
    /// <summary>
    /// �ЂƂO�ɑI�������J�[�h�̗D��x��ۊǂ���ϐ�
    /// </summary>
    private int _priority = 0;
    public int Priority { get => _priority; set => _priority = value; }

    public void DestroyObject(GameObject obj)
    {
        obj.transform.SetParent(transform);
        obj.transform.position = new Vector3(-999, -999, -999);
    }
}
