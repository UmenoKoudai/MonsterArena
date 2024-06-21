using System;
using System.Diagnostics;
using UnityEngine;
using Cysharp.Threading;

public class PlayerTurn : TurnBase
{
    private Stand _stand;
    private Select _select;
    private AttackStart _attackStart;
    private Attack _attack;
    private AttackEnd _attackEnd;
    private EndTurn _endTurn;

    /// <summary>初期化</summary>
    /// <param name="gameManager"></param>
    /// <param name="changeTurn"></param>
    public void Init(GameManager gameManager, GameManager.NowTurn changeTurn)
    {
        Build()
        StateChange(Phase.Stand);
    }

    public void Enter()
    {
        PlayerCamera.Priority = 10;
        EnemyCamera.Priority = 0;
    }

    public void ManualFixedUpdate()
    {
        _state.FixedUpdate();
    }

    /// <summary>ステートを変える</summary>
    /// <param name="change"></param>
    public override void StateChange(Phase change)
    {
        NowPhase = change;
    }

    public void SelectSkip()
    {
        if(_phase == Phase.Select)
            _state.Exit();
    }
}
