using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField]
    private Text _myText;

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

    private IAbility _specialAbility;
    public IAbility SpecialAbility { get => _specialAbility; set => _specialAbility = value; }

    public async UniTask UseAbility()
    {
        var data = FieldData.Instance;
        foreach (var ability in Ability)
        {
            ability.Use(data);
        }
    }
}
