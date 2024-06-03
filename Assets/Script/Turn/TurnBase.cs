using Cinemachine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TurnBase : MonoBehaviour
{
    [SerializeField, Tooltip("動かすモデル(プレイヤーかエネミー)")]
    private CharaBase _character;
    public CharaBase Character => _character;

    [SerializeField, Tooltip("セレクトフェーズで選んだカードを置いておく場所")]
    private GameObject SelectPanel;

    [SerializeField, Tooltip("セレクトフェーズの機能")]
    private SelectCard _selectCard;
    public SelectCard SelectCardScript => _selectCard;

    [SerializeField, Tooltip("セレクトフェーズの時間")]
    private SelectTimer _selectTimer;
    public SelectTimer SelectTimer => _selectTimer;

    [SerializeField, Tooltip("攻撃予定のカードをおいている場所")]
    private Image _standByField;
    public Image StandByField => _standByField;

    [SerializeField, Tooltip("今攻撃しているカードを置く場所")]
    private Image _attackField;
    public Image AttackField => _attackField;

    [SerializeField, Tooltip("セレクト画面のイメージ")]
    private GameObject[] _selectObject;
    public GameObject[] SelectObject => _selectObject;

    [SerializeField, Tooltip("今のターンを表示させるアニメーション")]
    private Animator _phaseAnimator;
    public Animator PhaseAnimator => _phaseAnimator;

    [Header("演出用のタイムライン")]
    [SerializeField, Tooltip("Selectカメラのタイムライン")]
    private PlayableDirector _cameraTimeLine;
    public PlayableDirector CameraTimeLine => _cameraTimeLine;

    [SerializeField, Tooltip("AttackStartのタイムライン")]
    private PlayableDirector _attackStartTimeLine;
    public PlayableDirector AttackStartTimeline => _attackStartTimeLine;

    [SerializeField, Tooltip("Attackカメラのタイムライン")]
    private PlayableDirector _attackTimeline;
    public PlayableDirector AttackTimeline => _attackTimeline;

    //バフや回復等の特殊な効果
    private List<IAbility> _specialAbility = new List<IAbility>();
    public List<IAbility> SpecialAbility => _specialAbility;

    public enum Phase
    {
        Stand,
        Select,
        AttackStart,
        Attack,
        AttackEnd,
        EndTurn,
    }

    public virtual void StateChange(Phase change)
    {
        Debug.LogError("オーバーライドしていません");
    }
}