using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ResultEnemy : MonoBehaviour
{
    [SerializeField, Tooltip("�ǂ���������������")]
    private ResultState _result;
    [SerializeField, Tooltip("�y���̃G�t�F�N�g")]
    private GameObject _effect;

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
            GetComponent<Rigidbody>().AddForce(-transform.forward * 10, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
    }
}
