using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]
public class CardData : ScriptableObject
{
    [SerializeField]
    private List<Data> data = new List<Data>();
    public List<Data> Data => data;
}

public class Data
{
    /// <summary>�J�[�h�̃A�C�R��</summary>
    [SerializeField, Tooltip("�J�[�h�̃A�C�R��")]
    private Sprite _cardIcon;
    public Sprite CardIcon => _cardIcon;

    /// <summary>�J�[�h�̗D��x</summary>
    [SerializeField, Tooltip("�J�[�h�̗D��x")]
    private int _priority;
    public int Priority => _priority;

    /// <summary>�J�[�h�̌���</summary>
    [SerializeField, Tooltip("�J�[�h�̌���")]
    [SerializeReference]
    [SubclassSelector]
    private IAbility _ability;
    public IAbility Ability => _ability;

    /// <summary>�J�[�h�̃^�[�Q�b�g</summary>
    [SerializeField, Tooltip("�J�[�h�̃^�[�Q�b�g")]
    [SerializeReference]
    [SubclassSelector]
    private ITarget _target;
    public ITarget Target => _target;
}
