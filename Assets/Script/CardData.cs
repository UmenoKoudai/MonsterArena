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
    /// <summary>カードのアイコン</summary>
    [SerializeField, Tooltip("カードのアイコン")]
    private Sprite _cardIcon;
    public Sprite CardIcon => _cardIcon;

    /// <summary>カードの優先度</summary>
    [SerializeField, Tooltip("カードの優先度")]
    private int _priority;
    public int Priority => _priority;

    /// <summary>カードの効果</summary>
    [SerializeField, Tooltip("カードの効果")]
    [SerializeReference]
    [SubclassSelector]
    private IAbility _ability;
    public IAbility Ability => _ability;

    /// <summary>カードのターゲット</summary>
    [SerializeField, Tooltip("カードのターゲット")]
    [SerializeReference]
    [SubclassSelector]
    private ITarget _target;
    public ITarget Target => _target;
}
