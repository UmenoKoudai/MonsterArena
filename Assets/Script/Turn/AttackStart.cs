using UnityEngine;

public class AttackStart : IStateMachine
{
    private TurnBase _turnBase;
    private Transform _movePos;
    private Vector3 _direction;
    private float _interval;
    private float _speed;
    private float _distance;

    public AttackStart(TurnBase turnBase)
    {
        _turnBase = turnBase;
        _direction = (_turnBase.Character.MovePos.position - _turnBase.Character.transform.position).normalized;
        _movePos = _turnBase.Character.MovePos;
        _interval = _turnBase.Character.Interval;
        _speed = _turnBase.Character.Speed;
    }

    public void Enter()
    {
        _turnBase.Character.Anim.SetBool("Run", true);
    }

    public void Exit()
    {
        Debug.Log("à⁄ìÆèIóπ");
        _turnBase.StateChange(TurnBase.Phase.Attack);
    }

    public void FixedUpdate()
    {
        _distance = Vector3.Distance(_turnBase.Character.transform.position, _movePos.position);
        _turnBase.Character.Rb.velocity = _direction * _speed;
        if (_distance < 10)
        {
            _turnBase.Character.Rb.velocity = Vector3.zero;
            _turnBase.Character.Anim.SetBool("Run", false);
            Exit();
        }
    }

    public void Update()
    {
    }
}
