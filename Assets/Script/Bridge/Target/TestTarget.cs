using UnityEngine;

public class TestTarget : ITarget
{
    public void Set(FieldData data)
    {
        Debug.Log("TestTarget");
    }
}
