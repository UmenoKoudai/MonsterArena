
public class EnemyTarget : ITarget
{
    public void Set(FieldData data)
    {
        data.Target = data.Enemy;
    }
}
