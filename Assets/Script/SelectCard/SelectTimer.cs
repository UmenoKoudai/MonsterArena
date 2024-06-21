using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Select�t�F�C�Y����莞�ԂŐ؂�ւ���N���X
/// </summary>
public class SelectTimer : MonoBehaviour
{
    [SerializeField, Tooltip("���b�Ńt�F�C�Y���I�����邩")]
    private int _maxTimer;

    [SerializeField, Tooltip("�^�C�}�[�̃J�E���g�\��")]
    private Text _timerCount;

    [SerializeField, Tooltip("�^�C�}�[�̃Q�[�W")]
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
                Debug.LogError("�^�C�}�[�������L�����Z�����܂���");
            }
        }
        _maxTimer = _defaultTimer;
    }
}
