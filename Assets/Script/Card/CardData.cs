using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]
public class CardData : ScriptableObject
{
    [SerializeField, Tooltip("�J�[�h�̃A�C�R��")]
    private Sprite _cardIcon;
    public Sprite CardIcon => _cardIcon;

    [SerializeField, Tooltip("�ړ����K�v���̃`�F�b�N")]
    [SerializeReference]
    [SubclassSelector]
    private ICondition _condition;
    public ICondition Condition => _condition;

    [SerializeField, Tooltip("�L�������ړ�������")]
    [SerializeReference]
    [SubclassSelector]
    private IMoveAbility _moveAbility;
    public IMoveAbility MoveAbility => _moveAbility;

    [SerializeField]
    private List<Data> data = new List<Data>();
    public List<Data> Data => data;
}

[Serializable]
public class Data
{ 
    /// <summary>�J�[�h�̗D��x</summary>
    [SerializeField, Tooltip("�J�[�h�̗D��x")]
    private int _priority;
    public int Priority => _priority;

    /// <summary>�J�[�h�̌���</summary>
    [SerializeField, Tooltip("�J�[�h�̌���")]
    [SerializeReference]
    [SubclassSelector]
    private List<IAbility> _ability = new List<IAbility>();
    public List<IAbility> Ability => _ability;

}
