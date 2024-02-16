using Cysharp.Threading.Tasks;
using UnityEngine;

public class AttackPosAbility : IMoveAbility
{
    public async UniTask Use(FieldData data)
    {
        var direction = (data.Attacker.MovePos.position - data.Attacker.transform.position).normalized;
        var interval = data.Attacker.Interval;
        var speed = data.Attacker.Speed;
        var distance = Vector3.Distance(data.Attacker.transform.position, data.Attacker.MovePos.position);
        data.Attacker.Anim.SetBool("Run", true);
        while (distance > interval)
        {
            distance = Vector3.Distance(data.Attacker.transform.position, data.Attacker.MovePos.position);
            data.Attacker.Rb.velocity = direction * speed;
            await UniTask.Delay(1);
        }
        data.Attacker.Rb.velocity = Vector3.zero;
        data.Attacker.Anim.SetBool("Run", false);
    }
}
