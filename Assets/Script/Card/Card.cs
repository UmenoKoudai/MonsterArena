using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Image[] _myImage;
    [SerializeField]
    private Text _myText;

    private Sprite _cardIcon;
    public Sprite CardIcon 
    {
        get => _cardIcon; 
        set
        {
            _cardIcon = value;
            for(int i = 0; i < 2; i++)
            {
                _myImage[i].sprite = _cardIcon;
            }
        }
    }

    private int _priority;
    public int Priority
    {
        get => _priority;
        set
        {
            _priority = value;
            _myText.text = _priority.ToString();
        }
    }

    private List<IAbility> _ability;
    public List<IAbility> Ability { get => _ability; set => _ability = value; }

    private ICondition _condition;
    public ICondition Condition { get => _condition; set => _condition = value; }

    private IMoveAbility _moveAbility;
    public IMoveAbility MoveAbility { get => _moveAbility; set => _moveAbility = value; }

    public async void UseAbility()
    {
        var data = FieldData.Instance;
        if (_condition.Check(data))
        {
            Debug.Log("êŠˆÚ“®");
            await _moveAbility.Use(data);
        }
        foreach (var ability in Ability)
        {
            ability.Use(data);
        }
    }
}
