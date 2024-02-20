using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TurnBase : MonoBehaviour
{
    [SerializeField, Tooltip("���������f��(�v���C���[���G�l�~�[)")]
    private CharaBase _character;
    public CharaBase Character => _character;

    [SerializeField, Tooltip("�Z���N�g�t�F�[�Y�őI�񂾃J�[�h��u���Ă����ꏊ")]
    private GameObject SelectPanel;

    [SerializeField, Tooltip("�Z���N�g�t�F�[�Y�̋@�\")]
    private SelectCard _selectCard;
    public SelectCard SelectCardScript => _selectCard;

    [SerializeField, Tooltip("�Z���N�g�t�F�[�Y�̎���")]
    private SelectTimer _selectTimer;
    public SelectTimer SelectTimer => _selectTimer;

    [SerializeField, Tooltip("�U���\��̃J�[�h�������Ă���ꏊ")]
    private Image _standByField;
    public Image StandByField => _standByField;

    [SerializeField, Tooltip("���U�����Ă���J�[�h��u���ꏊ")]
    private Image _attackField;
    public Image AttackField => _attackField;

    [SerializeField, Tooltip("�Z���N�g��ʂ̃C���[�W")]
    private GameObject[] _selectObject;
    public GameObject[] SelectObject => _selectObject;

    [SerializeField, Tooltip("���̃^�[����\��������A�j���[�V����")]
    private Animator _phaseAnimator;
    public Animator PhaseAnimator => _phaseAnimator;

    [SerializeField, Tooltip("�J�����̃^�C�����C��")]
    private PlayableDirector _cameraTimeLine;
    public PlayableDirector CameraTimeLine => _cameraTimeLine;

    [SerializeField, Tooltip("�L�����N�^�[�̃J����")]
    private CinemachineVirtualCamera _characterCamera;
    public CinemachineVirtualCamera CharacterCamera => _characterCamera;

    [SerializeField, Tooltip("�S�̃J����")]
    private CinemachineVirtualCamera _mainCamera;
    public CinemachineVirtualCamera MainCamera => _mainCamera;

    private List<IAbility> _specialAbility = new List<IAbility>();
    public List<IAbility> SpecialAbility => _specialAbility;

    public enum Phase
    {
        Stand,
        Select,
        AttackStart,
        Attack,
        AttackEnd,
        EntTurn,
    }

    public virtual void StateChange(Phase change)
    {
        Debug.LogError("�I�[�o�[���C�h���Ă��܂���");
    }
}