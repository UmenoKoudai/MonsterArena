using System;
using UnityEngine;

/// <summary>
/// ‘Šè‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚éŒø‰Ê
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
