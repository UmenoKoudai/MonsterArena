using System;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public class PlayerMoveState : IStateMachine
{
    private Player _player;
    private float _h;
    private float _v;

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
        dirForward = Camera.main.transform.TransformDirection(dirForward);
        dirForward.y = 0;
        if(_v != 0)
        {
            _player.transform.forward = dirForward;
        }
        _player.Rb.velocity = dirForward * _player.Speed + _player.Rb.velocity.y * Vector3.up;
    }

    public void Update()
    {
        _player.Anim.SetFloat("Speed", _player.Rb.velocity.magnitude);
        var currentMouse = Mouse.current;
        if(currentMouse.leftButton.wasPressedThisFrame)
        {
            _player.StateChange(Player.PlayerState.Attack);
        }
    }

}
