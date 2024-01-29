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
        await Timer();
    }

    async UniTask Timer()
    {
        while (_maxTimer > 0)
        {
            _maxTimer--;
            _timerCount.text = _maxTimer.ToString();
            _timerGauge.fillAmount -= 0.1f;
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }
        _maxTimer = _defaultTimer;
    }
}
