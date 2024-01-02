using System;
using UnityEngine;

[Serializable]
public class PlayerMoveState : IStateMachine
{
    Player _player;
    float _h;
    float _v;

    public PlayerMoveState(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
    }

    public void Exit()
    {
        
    }

    public void FixedUpdate()
    {
        _h = _player.Direction.x;
        _v = _player.Direction.z;
        var dirForward = Vector3.forward * _v + Vector3.right * _h;
        _player.Rb.velocity = _player.Direction * _player.Speed;
    }

    public void Update()
    {
        
    }

}
