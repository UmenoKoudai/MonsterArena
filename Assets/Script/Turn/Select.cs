using Cysharp.Threading.Tasks;
using System;
using System.Diagnostics;
using System.Threading;
using Unity.VisualScripting.Antlr3.Runtime;

/// <summary>
/// Select�t�F�C�Y�Ŏ��s�����N���X
/// </summary>
public class Select : IStateMachine
{
    private TurnBase _turnBase;
    private SelectCard.Turn _turn;
    private CancellationTokenSource _cancellationTokenSource;
    public CancellationToken Token => _cancellationTokenSource.Token;

    public Select(TurnBase turnBase, SelectCard.Turn turn)
    {
        _turnBase = turnBase;
        _turn = turn;
    }

    public async void Enter()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        _turnBase.PhaseAnimator.Play("Select");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        //Select�Ŏg�p����I�u�W�F�N�g��\��������
        foreach (var obj in _turnBase.SelectObject)
        {
            obj.SetActive(true);
        }
        _turnBase.SelectCardScript.Init(_turn);
        _turnBase.SelectTimer.Init();
    }

    public async void Exit()
    {
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
        _turnBase.SelectTimer.ManualUpdate();
        if (GameManager.Instance.SelectTimer <= 0) Exit(); 
    }
}
