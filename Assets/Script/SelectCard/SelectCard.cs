using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectCard : MonoBehaviour
{
    [SerializeField, Tooltip("�J�[�h�f�b�L�̃X�N���v�^�u���I�u�W�F�N�g")]
    private CardData[] _cardDeck;

    [SerializeField, Tooltip("�I���t�B�[���h")]
    private GameObject[] _setCard;

    [SerializeField, Tooltip("�f�t�H���g�̃J�[�hPrefab")]
    private GameObject _cardPrefab;

    [SerializeField, Tooltip("�I�������J�[�h��u���Ă����ꏊ")]
    private GameObject _selectedField;

    [SerializeField, Tooltip("�J�[�h�I���̃C���^�[�o��")]
    private float _enemyInterval;

    private float _timer;
    private List<EnemyGetCard> _enemyCard = new List<EnemyGetCard>();

    /// <summary>�ǂ̃t�B�[���h����J�[�h���擾��������ۊǂ��Ă����N���X</summary>
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
        FieldData.Instance.Priority = 0;
    }

    public async void ManualUpdate(Turn nowTurn)
    {
        //
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
                var setCard = _setCard[(int)SetCard.Down];
                Card card = setCard.GetComponentInChildren<Card>();
                if (FieldData.Instance.Priority > card.Priority) return;
                FieldData.Instance.Priority = card.Priority;
                card.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(card);
                CardDistribute(setCard);
            }
        }
        //�G�̃J�[�h�I���V�X�e��
        else
        {
            _timer += Time.deltaTime;
            if (_timer > _enemyInterval)
            {
                _timer = 0;
                if (_enemyCard.Count <= 0) return;
                var get = _enemyCard[0];
                _enemyCard.RemoveAt(0);
                if (FieldData.Instance.Priority > get._getCard.Priority) return;
                get._getCard.transform.SetParent(_selectedField.transform);
                FieldData.Instance.SelectCard.Enqueue(get._getCard);
                FieldData.Instance.Priority = get._getCard.Priority;
                CardDistribute(get._deck);
                _enemyCard.Add(new EnemyGetCard(get._deck, get._deck.GetComponentInChildren<Card>()));
                //Swap(_enemyCard[0], _enemyCard[_enemyCard.Count - 1]);
            }
        }
    }

    /// <summary>�D��x���Ⴂ���ɕ��בւ���</summary>
    /// <param name="a">�擪�̒l</param>
    /// <param name="b">�ǉ������l</param>
    void Swap(EnemyGetCard a, EnemyGetCard b)
    {
        //�ǉ������l�̗D��x���擪�̗D��x��菬������ΐ擪�Ɏ����Ă���
        if (a._getCard.Priority > b._getCard.Priority)
        {
            _enemyCard[0] = b;
            _enemyCard[_enemyCard.Count - 1] = a;
        }
    }

    /// <summary>�����_���ȃf�b�L���烉���_���ȃJ�[�h���擾</summary>
    /// <param name="selectCard">�ǂ̈ʒu�̃J�[�h��I��������</param>
    void CardDistribute(GameObject selectCard)
    {
        int deckIndex = UnityEngine.Random.RandomRange(0, _cardDeck.Length);
        CardData selectDeck = _cardDeck[deckIndex];
        int cardIndex = UnityEngine.Random.Range(0, selectDeck.Data.Count);
        Card card = null;
        if (selectDeck.Data[cardIndex].AbilityCardPrefab is null)
        {
            card = Instantiate(_cardPrefab, selectCard.transform.position, Quaternion.identity).GetComponent<Card>();
        }
        else
        {
            card = Instantiate(selectDeck.Data[cardIndex].AbilityCardPrefab, selectCard.transform.position, Quaternion.identity).GetComponent<Card>();
        }
        card.name = selectDeck.Data[cardIndex].Priority.ToString();
        card.transform.SetParent(selectCard.transform);
        card.Ability = selectDeck.Data[cardIndex].Ability;
        card.Priority = selectDeck.Data[cardIndex].Priority;
        if (selectDeck.Data[cardIndex].SpecialAbility is null) return;
        card.SpecialAbility = selectDeck.Data[cardIndex].SpecialAbility;
    }

    /// <summary>�I���ł��Ȃ������J�[�h�����Z�b�g����</summary>
    public async UniTask CardReset()
    {
        foreach (var index in Enum.GetValues(typeof(SetCard)))
        {
            var card = _setCard[(int)index].transform;
            for(int i = 0; i < card.transform.childCount; i++)
            {
                Destroy(card.transform.GetChild(i).gameObject);
            }
        }
        FieldData.Instance.Priority = 0;
    }
}