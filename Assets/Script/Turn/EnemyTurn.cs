public class EnemyTurn : TurnBase
{
    private Phase _phase;
    public Phase NowPhase
    {
        get => _phase;
        set
        {
            if (_phase == value) return;
            _phase = value;
            switch (_phase)
            {
                case Phase.Stand:
                    _stand.Enter();
                    break;
                case Phase.Select:
                    _select.Enter();
                    break;
                case Phase.Move:
                    _move.Enter();
                    break;
                case Phase.Attack:
                    _attack.Enter();
                    break;
                case Phase.EntTurn:
                    _endTurn.Enter();
                    break;
            }
        }
    }

    private Stand _stand;
    private Select _select;
    private Move _move;
    private Attack _attack;
    private EndTurn _endTurn;


    public void Init(GameManager gameManager, GameManager.NowTurn changeTurn)
    {
        FieldData.Instance.EnemyTurn = this;
        _stand = new Stand(this);
        _select = new Select(this, SelectCard.Turn.Enemy);
        _move = new Move(this);
        _attack = new Attack(this);
        _endTurn = new EndTurn(gameManager, changeTurn, this);
    }

    public void ManualUpdate()
    {
        switch (_phase)
        {
            case Phase.Stand:
                _stand.Update();
                break;
            case Phase.Select:
                _select.Update();
                break;
            case Phase.Move:
                _move.Update();
                break;
            case Phase.Attack:
                _attack.Update();
                break;
            case Phase.EntTurn:
                _endTurn.Update();
                break;
        }
    }

    public void ManualFixedUpdate()
    {
        switch (_phase)
        {
            case Phase.Stand:
                _stand.FixedUpdate();
                break;
            case Phase.Select:
                _select.FixedUpdate();
                break;
            case Phase.Move:
                _move.FixedUpdate();
                break;
            case Phase.Attack:
                _attack.FixedUpdate();
                break;
            case Phase.EntTurn:
                _endTurn.FixedUpdate();
                break;
        }
    }

    public override void StateChange(Phase change)
    {
        NowPhase = change;
    }
}
