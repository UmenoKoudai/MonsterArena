using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectTimer : MonoBehaviour
{
    [SerializeField]
    private int _maxTimer;

    [SerializeField]
    private Text _timerCount;

    [SerializeField]
    private Image _timerGauge;

    private int _defaultTimer;

    public async UniTask Init()
    {
        _timerCount.text = _maxTimer.ToString();
        _defaultTimer = _maxTimer;
        Debug.Log("TimerStart");
        await Timer();
        Debug.Log("TimerEnd");
    }

    async UniTask Timer()
    {
        while (_maxTimer >= 0)
        {
            Debug.Log("TimerCount’†");
            _maxTimer--;
            _timerCount.text = _maxTimer.ToString();
            _timerGauge.fillAmount -= 1 / _defaultTimer;
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }
        _maxTimer = _defaultTimer;
    }
}
