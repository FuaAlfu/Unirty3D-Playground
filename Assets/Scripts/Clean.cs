using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.9.17
/// </summary>

public class Clean : MonoBehaviour
{
    [SerializeField]
    private float _timer = 2f;
    
    void Start()
    {
        Destroy(gameObject, _timer);
    }
}
