using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �U���̓A�b�v�̌���
/// </summary>
[SerializeField]
public class AttackBuffAbility : IAbility
{
    [SerializeField]
    private int _value;
    public void Use(FieldData data)
    {
        AudioManager.Instance.SeClass.Play(AudioManager.SE.SEClip.BuffAbility);
        data.Attacker.AttackBuff(_value);
    }
}
