using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlay : IAbility
{
    [SerializeField]
    private string _animName;

    public void Use(FieldData data)
    {
        data.Target.Anim.Play(_animName);
    }
}
