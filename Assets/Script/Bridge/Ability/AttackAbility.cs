using System;
using UnityEngine;

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
