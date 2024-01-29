using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Attack : IStateMachine
{
    private PlayerTurn _player;
    private EnemyTurn _enemy;
    private Queue<Card> _selectCard = new Queue<Card>();
    private Image _standByField = null;
    private Image _attackField = null;
    private List<Card> _useCard = new List<Card>();

    public void Init(PlayerTurn player = null, EnemyTurn enemy = null)
    {
        if (!(player is null))
        {
            _player = player;
            _standByField = _player.StandByField;
            _attackField = _player.AttackField;
        }
        if (!(enemy is null))
        {
            _enemy = enemy;
            _standByField = _enemy.StandByField;
            _attackField = _enemy.AttackField;
        }
    }

    public async void Enter()
    {
        _selectCard = FieldData.Instance.SelectCard;
        _standByField.gameObject.SetActive(true);
        _attackField.gameObject.SetActive(true);
        for (int i = 0; i < _selectCard.Count; i++)
        {
            var card = _selectCard.Dequeue();
            _useCard.Add(card);
            card.transform.SetParent(_standByField.transform);
        }
        await CardUse();
        Exit();
        if (!(_player is null)) _player.StateChange(PlayerTurn.Phase.EntTurn);
        else _enemy.StateChange(EnemyTurn.Phase.EntTurn);
    }

    async UniTask CardUse()
    {
        foreach(var card in _useCard)
        {
            card.UseAbility();
            card.transform.SetParent(_attackField.transform);
            await UniTask.Delay(TimeSpan.FromSeconds(3));
            FieldData.Instance.DestroyObject(card.gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }
    }

    public void Exit()
    {
        _standByField.gameObject.SetActive(false);
        _attackField.gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
