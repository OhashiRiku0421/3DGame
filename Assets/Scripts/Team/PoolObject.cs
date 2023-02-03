using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField]
    private float _teamSpeed;
    private Rigidbody _rb;
    private Transform _transform;
    public Vector3 v3 = new Vector3();

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Init(Transform trans)
    {
        _transform = trans;
    }

    private void Update()
    {
        //Test();
    }

    private void Test()
    {
        var x = _transform.position - transform.position;
        _rb.velocity = new Vector3(x.x, 0, x.z) * _teamSpeed + new Vector3(0, _rb.velocity.y, 0);
    }
}
