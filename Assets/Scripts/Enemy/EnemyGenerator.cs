using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform _rangeLeft;

    [SerializeField]
    private Transform _rangeRight;

    [SerializeField]
    private ObjectPool _pool;

    [SerializeField]
    private int _enemyNum = 10;

    [SerializeField]
    private float _attackInterval = 5f;

    private bool _isAttack = true;

    private void Start()
    {
        _isAttack = true;
        StartCoroutine(AttackInterval());
    }

    private void Update()
    {
        RandomGenerator();
    }

    private void RandomGenerator()
    {
        if(!_isAttack)
        {
            for (int i = 0; i < _enemyNum; i++)
            {
                var x = Random.Range(_rangeLeft.position.x, _rangeRight.position.x);
                var z = Random.Range(_rangeLeft.position.z, _rangeRight.position.z);
                _pool.PoolPop(new Vector3(x, 0, z));
            }
            _isAttack = true;
            StartCoroutine(AttackInterval());
        }
    }

    IEnumerator AttackInterval()
    {
        yield return new WaitForSeconds(_attackInterval);
        _isAttack = false;
    }
}
