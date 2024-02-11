using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class RecoveryAbility : IAbility
{
    [SerializeField]
    private int _value;
    public void Use(FieldData data)
    {
        data.Attacker.Recovery(_value);
    }
}
