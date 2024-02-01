using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class Attack : IStateMachine
{
    private TurnBase _turnBase;
    private Queue<Card> _selectCard = new Queue<Card>();
    private Image _standByField = null;
    private Image _attackField = null;
    private List<Card> _useCard = new List<Card>();

    public Attack(TurnBase turnBase)
    {
        _turnBase = turnBase;
        _standByField = turnBase.StandByField;
        _attackField = turnBase.AttackField;
    }

    public async void Enter()
    {
        _selectCard = FieldData.Instance.SelectCard;
        int selectCount = _selectCard.Count;
        _standByField.gameObject.SetActive(true);
        _attackField.gameObject.SetActive(true);
        for (int i = 0; i < selectCount; i++)
        {
            var card = _selectCard.Dequeue();
            _useCard.Add(card);
            card.transform.SetParent(_standByField.transform);
        }
        await CardUse();
        Exit();
        _turnBase.StateChange(TurnBase.Phase.EntTurn);
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
        _useCard.Clear();
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
