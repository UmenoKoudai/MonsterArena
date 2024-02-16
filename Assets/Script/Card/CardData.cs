using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardData")]
public class CardData : ScriptableObject
{
    [SerializeField, Tooltip("カードのアイコン")]
    private Sprite _cardIcon;
    public Sprite CardIcon => _cardIcon;

    [SerializeField, Tooltip("移動が必要かのチェック")]
    [SerializeReference]
    [SubclassSelector]
    private ICondition _condition;
    public ICondition Condition => _condition;

    [SerializeField, Tooltip("キャラを移動させる")]
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
    /// <summary>カードの優先度</summary>
    [SerializeField, Tooltip("カードの優先度")]
    private int _priority;
    public int Priority => _priority;

    /// <summary>カードの効果</summary>
    [SerializeField, Tooltip("カードの効果")]
    [SerializeReference]
    [SubclassSelector]
    private List<IAbility> _ability = new List<IAbility>();
    public List<IAbility> Ability => _ability;

}
