using Cysharp.Threading.Tasks;
using System;

/// <summary>
/// Selectフェイズで実行されるクラス
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
        //Selectで使用するオブジェクトを表示させる
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
        //Selectで使用するオブジェクトを非表示にする
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
