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
    private GameObject _leftCard;
    [SerializeField]
    private GameObject _rightCard;
    [SerializeField]
    private GameObject _upCard;
    [SerializeField]
    private GameObject _downCard;
    [SerializeField]
    private GameObject _cardPrefab;
    [SerializeField]
    private GameObject _selectedField;

    public void Init()
    {
        CardDistribute(_leftCard);
        CardDistribute(_rightCard);
        CardDistribute(_upCard);
        CardDistribute(_downCard);
    }

    public void ManualUpdate()
    {
        if(Input.GetButtonDown("Left"))
        {
            Card card = _leftCard.GetComponentInChildren<Card>();
            card.transform.SetParent(_selectedField.transform);
            FieldData.Instance.SelectCard.Enqueue(card);
            CardDistribute(_leftCard);
        }
        if (Input.GetButtonDown("Right"))
        {
            Card card = _rightCard.GetComponentInChildren<Card>();
            card.transform.SetParent(_selectedField.transform);
            FieldData.Instance.SelectCard.Enqueue(card);
            CardDistribute(_rightCard);
        }
        if (Input.GetButtonDown("Up"))
        {
            Card card = _upCard.GetComponentInChildren<Card>();
            card.transform.SetParent(_selectedField.transform);
            FieldData.Instance.SelectCard.Enqueue(card);
            CardDistribute(_upCard);
        }
        if (Input.GetButtonDown("Down"))
        {
            Card card = _downCard.GetComponentInChildren<Card>();
            card.transform.SetParent(_selectedField.transform);
            FieldData.Instance.SelectCard.Enqueue(card);
            CardDistribute(_downCard);
        }
    }

    void CardDistribute(GameObject selectCard)
    {
        CardData selectDeck = null;
        int deckIndex = UnityEngine.Random.RandomRange(0, 5);
        switch(deckIndex)
        {
            case 0:
                selectDeck = _attackCardData;
                break;
            case 1:
                selectDeck = _recoveryCardData;
                break;
            case 2:
                selectDeck= _attackBuffData;
                break;
            case 3:
                selectDeck= _defenseBuffData;
                break;
        }
        int cardIndex = UnityEngine.Random.Range(0, selectDeck.Data.Count);
        var card = Instantiate(_cardPrefab, selectCard.transform.position, Quaternion.identity).GetComponent<Card>();
        card.Ability = selectDeck.Data[cardIndex].Ability;
        card.Target = selectDeck.Data[cardIndex].Target;
        card.Priority = selectDeck.Data[cardIndex].Priority;
    }
}