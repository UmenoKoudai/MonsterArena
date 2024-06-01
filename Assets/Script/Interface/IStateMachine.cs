public interface IStateMachine
{
    /// <summary>
    /// 自分のステートに切り替わった時に一度だけ呼び出される
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// 他のステータスに切り替わった時に一度だけ呼び出される
    /// </summary>
    public abstract void Exit();
    /// <summary>
    /// 自分のステートの時に毎フレーム呼ばれる
    /// </summary>
    public abstract void Update();
    /// <summary>
    /// 自分のステートの時に毎フレーム呼ばれる(Fixed)
    /// </summary>
    public abstract void FixedUpdate();
}
