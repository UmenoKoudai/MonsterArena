using Cysharp.Threading.Tasks;
using System;
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
