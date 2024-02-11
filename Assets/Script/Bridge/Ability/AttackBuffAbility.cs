using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class AttackBuffAbility : IAbility
{
    [SerializeField]
    private int _value;
    public void Use(FieldData data)
    {
        data.Attacker.AttackBuff(_value);
    }
}
