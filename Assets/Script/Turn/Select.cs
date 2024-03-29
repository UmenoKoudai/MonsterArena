using Cysharp.Threading.Tasks;
using System;

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
        _turnBase.CharacterCamera.Priority = 10;
        _turnBase.MainCamera.Priority = 0;
        _turnBase.CameraTimeLine.Play();
        _turnBase.PhaseAnimator.Play("Select");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        foreach (var obj in _turnBase.SelectObject)
        {
            obj.SetActive(true);
        }
        _turnBase.SelectCardScript.Init(_turn);
        await _turnBase.SelectTimer.Init();
        Exit();
        _turnBase.StateChange(TurnBase.Phase.AttackStart);
    }

    public async void Exit()
    {
        await _turnBase.SelectCardScript.CardReset();
        foreach (var obj in _turnBase.SelectObject)
        {
            obj.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
        _turnBase.SelectCardScript.ManualUpdate(_turn);
    }
}
