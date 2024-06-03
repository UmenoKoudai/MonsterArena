using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// Select�t�F�C�Y�Ŏ��s�����N���X
/// </summary>
public class Select : IStateMachine
{
    private TurnBase _turnBase;
    private SelectCard.Turn _turn;

    public Select(TurnBase turnBase, SelectCard.Turn turn)
    {
        _turnBase = turnBase;
        _turn = turn;
    }

    public async void Enter()
    {
        _turnBase.CameraTimeLine.Play();
        _turnBase.PhaseAnimator.Play("Select");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        //Select�Ŏg�p����I�u�W�F�N�g��\��������
        foreach (var obj in _turnBase.SelectObject)
        {
            obj.SetActive(true);
        }
        _turnBase.SelectCardScript.Init(_turn);
        await _turnBase.SelectTimer.Init();
        Exit();
    }

    public async void Exit()
    {
        _turnBase.CameraTimeLine.Stop();
        await _turnBase.SelectCardScript.CardReset();
        //Select�Ŏg�p����I�u�W�F�N�g���\���ɂ���
        foreach (var obj in _turnBase.SelectObject)
        {
            obj.SetActive(false);
        }
        _turnBase.StateChange(TurnBase.Phase.AttackStart);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _turnBase.SelectCardScript.ManualUpdate(_turn);
    }
}
