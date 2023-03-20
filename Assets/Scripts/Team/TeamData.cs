using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TeamData
{
    [SerializeField, Tooltip("ミイラの移動速度")]
    private float _moveSpeed = 4f;

    private Transform _transform;

    public void Init(Transform transform)
    {
        _transform = transform;
    }

    public void Move()
    {
        _transform.Translate(Vector3.forward * Time.fixedDeltaTime * _moveSpeed);
    }
}
