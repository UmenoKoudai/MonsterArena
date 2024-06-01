using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// カードの効果等の情報を格納するクラス
/// </summary>
public class Card : MonoBehaviour
{
    [SerializeField,Tooltip("カードに記載されている数字")]
    private Text _myText;

    /// <summary>
    /// カードの優先度
    /// </summary>
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

    /// <summary>
    /// 基本の攻撃アビリティ
    /// </summary>
    private List<IAbility> _ability;
    public List<IAbility> Ability { get => _ability; set => _ability = value; }

    /// <summary>
    /// バフ、デバフ等の特殊な効果
    /// </summary>
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
