using Cysharp.Threading.Tasks;
using UnityEngine;

public static class BackStep
{
    public static async UniTask BasePositionMove(Vector3 target, Transform nowPos, int angle, CharaBase targetChara)
    {
        targetChara.transform.position = target + new Vector3(0, 3, 0);
        var distance = Vector3.Distance(nowPos.position, target);
        while (distance > 0.5f)
        {
            distance = Vector3.Distance(nowPos.position, target);
            await UniTask.Delay(1);
        }
    }
}
