using UnityEngine;

public class PlayerAttackState : IStateMachine
{
    private Player _player;
    private float _index;
    public PlayerAttackState(Player player)
    {
        _player = player;
    }
    public void Enter()
    {
        _index++;
        if(_index > 3)
        {
            _index = 1;
        }
        //Debug.Log(_index);
        switch(_index)
        {
            case 1:
                _player.Anim.Play("Attack1");
                break;
            case 2:
                _player.Anim.Play("Attack2");
                break;
            case 3:
                _player.Anim.Play("Attack3");
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
        throw new System.NotImplementedException();
    }
}
