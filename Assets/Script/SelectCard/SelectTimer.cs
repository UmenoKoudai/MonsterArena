using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Selectフェイズを一定時間で切り替えるクラス
/// </summary>
public class SelectTimer : MonoBehaviour
{
    [SerializeField, Tooltip("何秒でフェイズを終了するか")]
    private int _maxTimer;

    [SerializeField, Tooltip("タイマーのカウント表示")]
    private Text _timerCount;

    [SerializeField, Tooltip("タイマーのゲージ")]
    private Image _timerGauge;

    private int _defaultTimer = 99;

    public async UniTask Init()
    {
        _timerGauge.fillAmount = 1;
        _timerCount.text = _maxTimer.ToString();
        _maxTimer = _defaultTimer;
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
    }
}
