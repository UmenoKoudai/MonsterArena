using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �J�[�h�̌��ʓ��̏����i�[����N���X
/// </summary>
public class Card : MonoBehaviour
{
    [SerializeField,Tooltip("�J�[�h�ɋL�ڂ���Ă��鐔��")]
    private Text _myText;

    /// <summary>
    /// �J�[�h�̗D��x
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
    /// ��{�̍U���A�r���e�B
    /// </summary>
    private List<IAbility> _ability;
    public List<IAbility> Ability { get => _ability; set => _ability = value; }

    /// <summary>
    /// �o�t�A�f�o�t���̓���Ȍ���
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
