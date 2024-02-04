public class PlayerTarget : ITarget
{
    public void Set(FieldData data)
    {
        data.Target = data.Player;
    }
}
