using Cysharp.Threading.Tasks;
using System;
using UnityEngine;


/// <summary>
/// キャラが攻撃を開始するときに実行されるクラス
/// </summary>
public class AttackStart : IStateMachine
{
    private TurnBase _turnBase;
    private Transform _movePos;
    private Vector3 _direction;
    private float _interval;
    private float _speed;
    private float _distance;
    private bool _animeFinish = false;

    public AttackStart(TurnBase turnBase)
    {
        _turnBase = turnBase;
        //移動先のベクトルを計算
        _direction = (_turnBase.Character.MovePos.position - _turnBase.Character.transform.position).normalized;
        _movePos = _turnBase.Character.MovePos;
        _interval = _turnBase.Character.Interval;
        _speed = _turnBase.Character.Speed;
    }

    public async void Enter()
    {
        _turnBase.PhaseAnimator.Play("Attack");
        await UniTask.Delay(TimeSpan.FromSeconds(1));
        _turnBase.Character.Anim.SetBool("Dush", true);
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        _animeFinish = true;
        _turnBase.Character.Anim.SetBool("Dushed", true);
    }

    public void Exit()
    {
        _turnBase.Character.Rb.velocity = Vector3.zero;
        _turnBase.Character.Anim.SetBool("Dushed", false);
        _turnBase.Character.Anim.SetBool("Dush", false);
        _animeFinish = false;
        _turnBase.StateChange(TurnBase.Phase.Attack);
    }

    public void FixedUpdate()
    {
        if (!_animeFinish) return;
        _distance = Vector3.Distance(_turnBase.Character.transform.position, _movePos.position);
        _turnBase.Character.Rb.velocity = _direction * _speed * 3;
        if (_distance < 10)
        {
            Exit();
        }
    }

    public void Update()
    {
    }
}
