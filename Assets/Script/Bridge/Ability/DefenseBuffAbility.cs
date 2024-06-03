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
        AudioManager.Instance.SeClass.Play(AudioManager.SE.SEClip.BuffAbility);
        data.Attacker.DefenseBuff(_value);
    }
}
