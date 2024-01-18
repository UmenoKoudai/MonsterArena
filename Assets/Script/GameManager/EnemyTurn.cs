using System;
using UnityEngine;

public class EnemyTurn : TurnBase
{
    [SerializeField]
    Enemy _enemy;

    public Action<GameManager.NowTurn> OnTurnChange;

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
    private Attack _attack;
    private EndTurn _endTurn;

    public enum Phase
    {
        Stand,
        Select,
        Attack,
        EntTurn,
    }

    public void Init()
    {
        FieldData.Instance.EnemyTurn = this;
        _stand = new Stand();
        _select = new Select();
        _attack = new Attack();
        _endTurn = new EndTurn();
        _stand.Init(this);
        _select.Init(this);
        _attack.Init(this);
        _endTurn.Init(this);
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
            case Phase.Attack:
                _attack.FixedUpdate();
                break;
            case Phase.EntTurn:
                _endTurn.FixedUpdate();
                break;
        }
    }
}
