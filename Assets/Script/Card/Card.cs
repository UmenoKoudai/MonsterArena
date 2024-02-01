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

    private IAbility _ability;
    public IAbility Ability { get => _ability; set => _ability = value; }
    
    private ITarget _target;
    public ITarget Target { get => _target; set => _target = value; }

    public void UseAbility()
    {
        Target.Set();
        Ability.Use();
    }
}
