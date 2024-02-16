using Cysharp.Threading.Tasks;

public class BasePosAbility : IMoveAbility
{
    public async UniTask Use(FieldData data)
    {
        var target = data.Attacker;
        await BackStep.BasePositionMove(target.BasePos, target.transform, target.Angle, target);
    }
}
