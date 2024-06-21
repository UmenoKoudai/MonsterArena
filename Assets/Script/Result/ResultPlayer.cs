using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Playables;

public class ResultPlayer : MonoBehaviour
{
    [SerializeField, Tooltip("どっちが勝利したか")]
    private ResultState _result;
    [SerializeField, Tooltip("土煙のエフェクト")]
    private GameObject _effect;
    [SerializeField, Tooltip("リザルトの表示")]
    private PlayableDirector _resultTimeline;

    enum ResultState
    {
        Player,
        Enemy,
        Draw,
    }

    async void Start()
    {
        Time.timeScale = 1.0f;
        if (_result == ResultState.Player)
        {
            AudioManager.Instance.SeClass.Play(AudioManager.SE.SEClip.Kick);
            GetComponent<Animator>().Play("Attack3");
        }
        else if(_result == ResultState.Enemy)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            GetComponent<Rigidbody>().AddForce(-transform.forward * 100, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.Instance.SeClass.Play(AudioManager.SE.SEClip.Bomb);
        _resultTimeline.Play();
        Instantiate(_effect, transform.position, Quaternion.identity);
        AudioManager.Instance.SeClass.Play(AudioManager.SE.SEClip.KO);
    }
}
