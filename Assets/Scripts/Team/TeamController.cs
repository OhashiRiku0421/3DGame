using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamController : MonoBehaviour
{
    [SerializeField]
    private float _teamSpeed;
    [SerializeField, Tooltip("チームを生成する範囲")]
    private Transform _rangeLeft;
    public Transform RangeLeft => _rangeLeft;

    [SerializeField, Tooltip("チームを生成する範囲")]
    private Transform _rangeRight;
    public Transform RangeRight => _rangeRight;

    private Rigidbody _rb;
    private Transform _playerTransform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ForwardMove();
    }

    public void ForwardMove()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * _teamSpeed);
    }
}
