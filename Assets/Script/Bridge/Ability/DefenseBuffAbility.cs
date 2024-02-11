using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class DefenseBuffAbility : IAbility
{
    [SerializeField]
    private int _value;
    public void Use(FieldData data)
    {
        data.Attacker.DefenseBuff(_value);
    }
}
