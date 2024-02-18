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
