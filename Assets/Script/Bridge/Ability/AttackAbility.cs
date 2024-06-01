using System;
using UnityEngine;

/// <summary>
/// 相手にダメージを与える効果
/// </summary>
[Serializable]
public class AttackAbility : IAbility
{
    [SerializeField]
    private int _attack;

    public void Use(FieldData data)
    {
        data.Target.Damage(data.Attacker.Attack * _attack);
    }
}
