public interface IStateMachine
{
    /// <summary>
    /// �����̃X�e�[�g�ɐ؂�ւ�������Ɉ�x�����Ăяo�����
    /// </summary>
    public abstract void Enter();
    /// <summary>
    /// ���̃X�e�[�^�X�ɐ؂�ւ�������Ɉ�x�����Ăяo�����
    /// </summary>
    public abstract void Exit();
    /// <summary>
    /// �����̃X�e�[�g�̎��ɖ��t���[���Ă΂��
    /// </summary>
    public abstract void Update();
    /// <summary>
    /// �����̃X�e�[�g�̎��ɖ��t���[���Ă΂��(Fixed)
    /// </summary>
    public abstract void FixedUpdate();
}
