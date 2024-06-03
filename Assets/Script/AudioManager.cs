using System;
using UnityEngine;
using static AudioManager.BGM;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private BGMClip _bgmEnum;

    [SerializeField]
    private BGM _bgmClass;
    public BGM BGMClass => _bgmClass;

    [SerializeField]
    private SE _seClass;
    public SE SeClass => _seClass;

    [SerializeField]

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }
            return _instance;
        }
    }

    private void Start()
    {
        AudioManager.Instance._bgmClass.Play(_bgmEnum);
    }

    [Serializable]
    public class BGM
    {
        [SerializeField, Tooltip("BGMを鳴らすAudioSource")]
        private AudioSource _bgmSound;
        [SerializeField, Tooltip("鳴らしたいBGM")]
        private AudioClip[] _bgmClip;

        public enum BGMClip
        {
            Title,
            Game,
            Result,
        }

        public void Play(BGMClip clip)
        {
            _bgmSound.PlayOneShot(_bgmClip[(int)clip]);
        }

    }

    [Serializable]
    public class SE
    {
        [SerializeField, Tooltip("SEを鳴らすAudioSource")]
        private AudioSource _seSound;
        [SerializeField, Tooltip("鳴らしたいSE")]
        private AudioClip[] _seClip;

        public enum SEClip
        {
            Attack,
            BuffAbility,
            Recovery,
            Click,
        }

        public void Play(SEClip clip) 
        {
            _seSound.PlayOneShot(_seClip[(int)clip]);
        }
    }
}
