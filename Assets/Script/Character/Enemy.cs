using UnityEngine;

public class Enemy : CharaBase
{

    private void Awake()
    {
        FieldData.Instance.Enemy = this;
        BasePos = transform.position;
        Rb = GetComponent<Rigidbody>();
    }
}
