using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自分のＨＰを回復させる効果
/// </summary>
[SerializeField]
public class RecoveryAbility : IAbility
{
    [SerializeField]
    private int _value;
    public void Use(FieldData data)
    {
        AudioManager.Instance.SeClass.Play(AudioManager.SE.SEClip.Recovery);
        data.Attacker.Recovery(_value);
    }
}
