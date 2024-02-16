using UnityEngine;

public class AttackPosition : ICondition
{
    public bool Check(FieldData data)
    {
        var target = data.Attacker;
        var distance = Vector3.Distance(target.MovePos.position, target.transform.position);
        Debug.Log(distance > target.Interval);
        return distance > target.Interval;
    }
}
