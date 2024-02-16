using Cysharp.Threading.Tasks;

public interface IMoveAbility
{
    public abstract UniTask Use(FieldData data);
}
