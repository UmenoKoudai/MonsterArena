using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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

    private async void Start()
    {
        _timerCount.text = _maxTimer.ToString();
        _defaultTimer = _maxTimer;
        await Timer();
    }

    async UniTask<bool> Timer()
    {
        while (true)
        {
            if (_maxTimer <= 0) return true;
            _maxTimer--;
            _timerGauge.fillAmount -= 1 / _defaultTimer;
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
        }
    }
}
