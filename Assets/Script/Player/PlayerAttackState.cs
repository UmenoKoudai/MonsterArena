using UnityEngine;
using Cysharp.Threading;
using Cysharp.Threading.Tasks;
using System;

public class PlayerAttackState : IStateMachine
{
    private Player _player;
    private float _index;
    private float _animationTime;
    private bool _isAnimation;

    public PlayerAttackState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        if (_isAnimation)return;
        _index++;
        if(_index > 3)
        {
            _index = 1;
        }
        switch(_index)
        {
            case 1:
                AnimationInterval("Attack1", 1.05f);
                break;
            case 2:
                AnimationInterval("Attack2", 1.22f);
                break;
            case 3:
                AnimationInterval("Attack3", 1.04f);
                break;
        }
        _player.StateChange(Player.PlayerState.Move);
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void FixedUpdate()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        if(!_isAnimation)
        {
            _player.StateChange(Player.PlayerState.Move);
        }
    }

    async void AnimationInterval(string name, float interval)
    {
        _isAnimation = true;
        _player.Anim.SetBool(name, _isAnimation);
        var a = await AnimationEnd(interval);
        _isAnimation = !a;
        _player.Anim.SetBool(name, _isAnimation);
    }

    async UniTask<bool> AnimationEnd(float interval)
    {
        float time = 0f;
        while(interval > time)
        {
            time += Time.deltaTime;
            await UniTask.Delay(1);
        }
        return true;
    }
}
