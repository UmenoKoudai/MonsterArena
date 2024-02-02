using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : CharaBase
{
    private void Awake()
    {
        FieldData.Instance.Player = this;
        BasePos = transform.position;
        Rb = GetComponent<Rigidbody>();
    }
}

