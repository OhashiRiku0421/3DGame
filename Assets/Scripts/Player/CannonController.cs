using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField]
    private Transform _muzzle;

    [SerializeField]
    private ObjectPool _pool;

    private Vector3 _dir;

    public void GunAttack()
    {
        _dir = _muzzle.position;
        _pool.PoolPop(_dir);
    }
}
