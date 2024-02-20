using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnd : IStateMachine
{
    private TurnBase _turnBase;

    public AttackEnd(TurnBase turnBase)
    {
        _turnBase = turnBase;
    }

    public async void Enter()
    {
        await BackStep.BasePositionMove(_turnBase.Character.BasePos, _turnBase.Character.transform, _turnBase.Character.Angle, _turnBase.Character);
        _turnBase.PhaseAnimator.Play("Ability");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        await UseSpecialAbility();
        Exit();
    }

    public void Exit()
    {
        _turnBase.StateChange(TurnBase.Phase.EntTurn);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }

    async UniTask UseSpecialAbility()
    {
        var data = FieldData.Instance;
        foreach(var ability in _turnBase.SpecialAbility)
        {
            ability.Use(data);
            await UniTask.Delay(TimeSpan.FromSeconds(0.5f));
        }
        _turnBase.SpecialAbility.Clear();
    }
}
