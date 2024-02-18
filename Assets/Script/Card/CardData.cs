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
    /// <summary>カードの優先度</summary>
    [SerializeField, Tooltip("カードの優先度")]
    private int _priority;
    public int Priority => _priority;

    [SerializeField, Tooltip("効果のあるカードの場合専用のカードPrefabをアタッチ")]
    private Card _abilityCardPrefab;
    public Card AbilityCardPrefab => _abilityCardPrefab;

    /// <summary>カードの効果</summary>
    [SerializeField, Tooltip("カードの効果")]
    [SerializeReference]
    [SubclassSelector]
    private List<IAbility> _ability = new List<IAbility>();
    public List<IAbility> Ability => _ability;

    [SerializeField, Tooltip("特殊効果")]
    [SerializeReference]
    [SubclassSelector]
    private IAbility _specialAbility;
    public IAbility SpecialAbility => _specialAbility;

}
