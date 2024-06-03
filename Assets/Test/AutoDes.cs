using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 自動的にオブジェクトを削除する
/// </summary>
public class AutoDes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }
}
