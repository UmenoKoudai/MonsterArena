using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// 選択したカードで攻撃するステート
/// </summary>
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
        for (int i = 0; i < selectCount; i++)
        {
            var card = _selectCard.Dequeue();
            _useCard.Add(card);
            card.transform.SetParent(_standByField.transform);
            if (card.SpecialAbility is null) continue;
            _turnBase.SpecialAbility.Add(card.SpecialAbility);
        }
        await CardUse();
        Exit();
    }

    /// <summary>
    /// 選択したカードを使用する
    /// </summary>
    /// <returns></returns>
    async UniTask CardUse()
    {
        foreach(var card in _useCard)
        {
            card.transform.SetParent(_attackField.transform);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            await card.UseAbility();
            FieldData.Instance.DestroyObject(card.gameObject);
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            GameManager.Instance.StateCheck();
        }
        _useCard.Clear();
    }

    public void Exit()
    {
        _turnBase.StateChange(TurnBase.Phase.AttackEnd);
    }

    public void FixedUpdate()
    {
    }

    public void Update()
    {
    }
}
