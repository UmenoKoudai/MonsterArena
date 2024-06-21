using Cysharp.Threading.Tasks;
using System;
using System.Threading;
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
    private float _gaugeCount;

    public async UniTask Init(CancellationToken token)
    {
        _timerGauge.fillAmount = 1;
        _timerCount.text = _maxTimer.ToString();
        _maxTimer = _defaultTimer;
        _gaugeCount = 1 / _maxTimer;
        await Timer(token);
    }

    async UniTask Timer(CancellationToken token)
    {
        while (_maxTimer > 0)
        {
            try
            {
                _maxTimer--;
                _timerCount.text = _maxTimer.ToString();
                _timerGauge.fillAmount -= _gaugeCount;
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: token);
            }
            catch(OperationCanceledException ex)
            {
                Debug.LogError("タイマー処理をキャンセルしました");
            }
        }
        _maxTimer = _defaultTimer;
    }
}
