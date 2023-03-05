using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("必要なチームの数")]
    private int _teamNum = 2;

    [SerializeField]
    private ObjectPool _teamPool = null;

    private bool _isPop = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TeamController>(out TeamController playercCntroller) && !_isPop)
        {
            _isPop = true;
            StartCoroutine(PopInterval());
            RandomTransform(playercCntroller.RangeLeft,
                playercCntroller.RangeRight);
        }
    }
    IEnumerator PopInterval()
    {
        yield return new WaitForSeconds(0.5f);
        _isPop = false;
    }

    private void RandomTransform(Transform rangeLeft, Transform rangeRight)
    {
        for (int i = 0; i < _teamNum; i++)
        {
            var x = Random.Range(rangeLeft.position.x, rangeRight.position.x);
            var z = Random.Range(rangeLeft.position.z, rangeRight.position.z);
            _teamPool.PoolPop(new Vector3(x, 0, z));
        }
    }
}
