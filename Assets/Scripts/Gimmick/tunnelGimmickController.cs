using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnelGimmickController : MonoBehaviour, IAddDamage
{

    [SerializeField, Tooltip("トンネルの出口")]
    private Transform _tunnelExit;

    [SerializeField]
    private ObjectPool _pool;

    public void AddDamage()
    {
        _pool.PoolPop(_tunnelExit.position);
    }
}
