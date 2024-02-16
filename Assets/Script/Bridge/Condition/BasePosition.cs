using UnityEngine;

public class BasePosition : ICondition
{
    public bool Check(FieldData data)
    {
        var target = data.Attacker;
        var distance = Vector3.Distance(target.BasePos, target.transform.position);
        Debug.Log(distance > target.Interval);
        return distance > target.Interval;
    }
}
