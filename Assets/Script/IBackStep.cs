using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public static class BackStep
{
    public static async UniTask BasePositionMove(Vector3 target, Transform nowPos, int angle, CharaBase targetChara)
    {
        Vector3 velocity = SpeedCalculation(nowPos.position, target, angle);
        var distance = Vector3.Distance(nowPos.position, target);
        while(distance > 0.5f)
        {
            distance = Vector3.Distance(nowPos.position, target);
            targetChara.Rb.AddForce(velocity * targetChara.Rb.mass, ForceMode.Impulse);
            await UniTask.Delay(1);
        }
    }

    static Vector3 SpeedCalculation(Vector3 pointA, Vector3 pointB, int angle)
    {
        //  éÀèoäpÇÉâÉWÉAÉìÇ…ïœä∑
        float red = angle * MathF.PI / 180;
        float x = Vector2.Distance(new Vector2(pointA.x, pointB.z), new Vector2(pointB.x, pointA.z));
        float y = pointA.y - pointB.y;
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(red), 2) * (x * Mathf.Tan(red) + y)));

        if (float.IsNaN(speed))
        {
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x * Mathf.Tan(red), pointB.z - pointA.z).normalized * speed);
        }
    }
}
