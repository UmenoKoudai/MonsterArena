using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Playables;

public class ResultEnemy : MonoBehaviour
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
        if (_result == ResultState.Enemy)
        {
            GetComponent<Animator>().Play("Attack3");
        }
        else if (_result == ResultState.Player)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
            GetComponent<Rigidbody>().AddForce(-transform.forward * 100, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("爆発");
        _resultTimeline.Play();
        Instantiate(_effect, other.transform.position, Quaternion.identity);
    }
}
