using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.9.20
/// </summary>

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private float _rollSpeed = 3;

    private bool _isMoving;

    void Update()
    {
        MakeCubeMovement();
    }

    private void MakeCubeMovement()
    {
        if (_isMoving) return;
        if(Input.GetKeyDown(KeyCode.D))
        {
            var anchor = transform.position + new Vector3(-0.5f, -.5f, 0);
            var axis = Vector3.Cross(Vector3.up, Vector3.left);
            StartCoroutine(Rolling(anchor, axis));
        }
    }

    private IEnumerator Rolling(Vector3 anchor, Vector3 axis)
    {
        _isMoving = true;
        for(int i = 0; i < (90 / _rollSpeed); i++)
        {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }
}
