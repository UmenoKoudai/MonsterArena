using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]
public class CardData : ScriptableObject
{
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

    [SerializeField, Tooltip("���ʂ̂���J�[�h�̏ꍇ��p�̃J�[�hPrefab���A�^�b�`")]
    private Card _abilityCardPrefab;
    public Card AbilityCardPrefab => _abilityCardPrefab;

    /// <summary>�J�[�h�̌���</summary>
    [SerializeField, Tooltip("�J�[�h�̌���")]
    [SerializeReference]
    [SubclassSelector]
    private List<IAbility> _ability = new List<IAbility>();
    public List<IAbility> Ability => _ability;

    [SerializeField, Tooltip("�������")]
    [SerializeReference]
    [SubclassSelector]
    private IAbility _specialAbility;
    public IAbility SpecialAbility => _specialAbility;

}
