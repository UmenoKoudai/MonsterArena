using System;
using UnityEngine;

[Serializable]
public class AnimPlay : IAbility
{
    [SerializeField]
    private string _animName;

    public void Use(FieldData data)
    {
        data.Attacker.Anim.Play(_animName);
    }
}
