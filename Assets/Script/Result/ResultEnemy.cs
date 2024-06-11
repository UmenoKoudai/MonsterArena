using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.Playables;

public class ResultEnemy : MonoBehaviour
{
    [SerializeField, Tooltip("�ǂ���������������")]
    private ResultState _result;
    [SerializeField, Tooltip("�y���̃G�t�F�N�g")]
    private GameObject _effect;
    [SerializeField, Tooltip("���U���g�̕\��")]
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
        Debug.Log("����");
        _resultTimeline.Play();
        Instantiate(_effect, other.transform.position, Quaternion.identity);
    }
}
