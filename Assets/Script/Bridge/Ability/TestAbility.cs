using UnityEngine;

public class TestAbility : IAbility
{
    public void Use(FieldData data)
    {
        Debug.Log("TestAbility");
    }
}
