using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField]
    private float _teamSpeed;

    private Rigidbody _rb;
    private Transform _playerTransform;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Init(Transform trans)
    {
        _playerTransform = trans;
    }

    private void Update()
    {
        MoveTest();
    }

    private void MoveTest()
    {
        var distance = _playerTransform.position - transform.position;
        _rb.velocity = new Vector3(distance.x, distance.y, distance.z - 2).normalized * _teamSpeed + new Vector3(0, _rb.velocity.y, 0);
    }
    //private void A()
    //{
    //    var distance = (_transform.position - transform.position);
    //    transform.Translate(new Vector3(distance.x, 0, distance.z - 1) * Time.deltaTime * _teamSpeed);
    //}
}
