using UnityEngine;
using Cysharp.Threading.Tasks;
using System;

public class EndTurn : IStateMachine
{
    private GameManager _gameManager;
    private TurnBase _turnBase;
    private GameManager.NowTurn _changeTurn;
    private CharaBase _character;

    public EndTurn(GameManager gameManager, GameManager.NowTurn change, TurnBase turnBase)
    {
        _turnBase = turnBase;
        _gameManager = gameManager;
        _changeTurn = change;
        _character = _turnBase.Character;
    }

    public async void Enter()
    {
        await BasePosition();
        _gameManager.TurnChange(_changeTurn);
        _turnBase.StateChange(TurnBase.Phase.Stand);
    }

    public void Exit()
    {
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }

    async UniTask BasePosition()
    {
        Vector3 target = _character.BasePos;
        int angle = _turnBase.Angle;
        Vector3 velocity = SpeedCalculation(_character.transform.position, target, angle);
        _character.Rb.AddForce(velocity * _character.Rb.mass, ForceMode.Impulse);
        float distance = Vector3.Distance(_character.transform.position, target);
        while (distance > 0.5f) { distance = Vector3.Distance(_character.transform.position, target); };
    }

    Vector3 SpeedCalculation(Vector3 pointA, Vector3 pointB, int angle)
    {
        //  射出角をラジアンに変換
        float red = angle * MathF.PI / 180;
        float x = Vector2.Distance(new Vector2(pointA.x, pointB.z), new Vector2(pointB.x, pointA.z));
        float y = pointA.y - pointB.y;
        float speed = Mathf.Sqrt(-Physics.gravity.y * Mathf.Pow(x, 2) / (2 * Mathf.Pow(Mathf.Cos(red), 2) * (x * Mathf.Tan(red) + y)));

        if(float.IsNaN(speed))
        {
            return Vector3.zero;
        }
        else
        {
            return (new Vector3(pointB.x - pointA.x * Mathf.Tan(red), pointB.z - pointA.z).normalized * speed);
        }
    }
}
