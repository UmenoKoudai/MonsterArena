using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _clip;

    public enum Clip
    {
        System1,
        System2,
        System3,
        Select,
        Attack,
        Move,
    }
}
