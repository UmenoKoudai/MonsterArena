using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectCard : MonoBehaviour
{
    [SerializeField]
    private CardData _attackCardData;
    [SerializeField]
    private CardData _recoveryCardData;
    [SerializeField]
    private CardData _attackBuffData;
    [SerializeField]
    private CardData _defenseBuffData;
    [SerializeField]
    private GameObject[] _setCard;
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private GameObject _selectedField;

    [SerializeField]
    private float _enemyInterval;

    private float _timer;
    private List<EnemyGetCard> _enemyCard = new List<EnemyGetCard>();

    class EnemyGetCard
    {
        public GameObject _deck;
        public Card _getCard;

        public EnemyGetCard(GameObject deck, Card getCard)
        {
            _deck = deck;
            _getCard = getCard;
        }
    }

    enum SetCard
    {
        Left,
        Right,
        Up,
        Down,
    }

    public enum Turn
    {
        Player,
        Enemy,
    }

    public void Init(Turn nowTurn)
    {
        foreach (var index in Enum.GetValues(typeof(SetCard)))
        {
            CardDistribute(_setCard[(int)index]);
        }
        if (nowTurn == Turn.Player) return;
        foreach (var index in Enum.GetValues(typeof(SetCard)))
        {
            var deck = _setCard[(int)index];
            _enemyCard.Add(new EnemyGetCard(deck, deck.GetComponentInChildren<Card>()));
            Swap(_enemyCard[0], _enemyCard[_enemyCard.Count - 1]);
        }
        _timer = 0f;
    }

    public async void ManualUpdate(Turn nowTurn)
    {
        if (nowTurn == Turn.Player)
        {
            if (Input.GetButtonDown("Left"))
            {
                var setCard = _setCard[(int)SetCard.Left];
                Card card = setCard.GetComponentInChildren<Card>();
                if (FieldData.Instance.Priority > card.Priority) return;
                FieldData.Instance.Priority = card.Priority;
                card.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(card);
                CardDistribute(setCard);
            }
            if (Input.GetButtonDown("Right"))
            {
                var setCard = _setCard[(int)SetCard.Right];
                Card card = setCard.GetComponentInChildren<Card>();
                if (FieldData.Instance.Priority > card.Priority) return;
                FieldData.Instance.Priority = card.Priority;
                card.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(card);
                CardDistribute(setCard);
            }
            if (Input.GetButtonDown("Up"))
            {
                var setCard = _setCard[(int)SetCard.Up];
                Card card = setCard.GetComponentInChildren<Card>();
                if (FieldData.Instance.Priority > card.Priority) return;
                FieldData.Instance.Priority = card.Priority;
                card.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(card);
                CardDistribute(setCard);
            }
            if (Input.GetButtonDown("Down"))
            {
                var setCard = _setCard[((int)SetCard.Down)];
                Card card = setCard.GetComponentInChildren<Card>();
                if (FieldData.Instance.Priority > card.Priority) return;
                FieldData.Instance.Priority = card.Priority;
                card.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(card);
                CardDistribute(setCard);
            }
        }
        else
        {
            _timer += Time.deltaTime;
            if(_timer > _enemyInterval)
            {
                _timer = 0;
                var get = _enemyCard[0];
                _enemyCard.RemoveAt(0);
                get._getCard.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(get._getCard);
                CardDistribute(get._deck);
                _enemyCard.Add(new EnemyGetCard(get._deck, get._deck.GetComponentInChildren<Card>()));
                Swap(_enemyCard[0], _enemyCard[_enemyCard.Count - 1]);
            }
        }
    }

    void Swap(EnemyGetCard a, EnemyGetCard b)
    {
        if(a._getCard.Priority > b._getCard.Priority)
        {
            _enemyCard[0] = b;
            _enemyCard[_enemyCard.Count - 1] = a;
        }
    }

    void CardDistribute(GameObject selectCard)
    {
        CardData selectDeck = null;
        int deckIndex = UnityEngine.Random.RandomRange(0, 4);
        switch (deckIndex)
        {
            case 0:
                selectDeck = _attackCardData;
                break;
            case 1:
                selectDeck = _recoveryCardData;
                break;
            case 2:
                selectDeck = _attackBuffData;
                break;
            case 3:
                selectDeck = _defenseBuffData;
                break;
        }
        int cardIndex = UnityEngine.Random.Range(0, selectDeck.Data.Count);
        var card = Instantiate(_cardPrefab, selectCard.transform.position, Quaternion.identity).GetComponent<Card>();
        card.transform.SetParent(selectCard.transform);
        card.Ability = selectDeck.Data[cardIndex].Ability;
        card.Target = selectDeck.Data[cardIndex].Target;
        card.Priority = selectDeck.Data[cardIndex].Priority;
    }
}