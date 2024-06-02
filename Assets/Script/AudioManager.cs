using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private BGM _bgmClass;
    public BGM BGMClass => _bgmClass;

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

    [Serializable]
    public class BGM
    {
        [SerializeField, Tooltip("BGM‚ð–Â‚ç‚·AudioSource")]
        private AudioSource _bgmSound;
        [SerializeField]
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
        [SerializeField, Tooltip("SE‚ð–Â‚ç‚·AudioSource")]
        private AudioSource _seSound;
    }
}
