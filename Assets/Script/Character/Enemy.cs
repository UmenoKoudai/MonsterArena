using UnityEngine;

public class Enemy : CharaBase
{
    private void Awake()
    {
        FieldData.Instance.Enemy = this;
        Rb = GetComponent<Rigidbody>();
    }
}
