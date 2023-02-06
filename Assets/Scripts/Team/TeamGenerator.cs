using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("必要なチームの数")]
    private int _teamNum = 10;

    [SerializeField]
    private TeamObjectPool _teamPool = null;

    public void Generator(Transform[] transforms, Transform playerPos)
    {
        for (int i = 0; i < _teamNum; i++)
        {
            TeamPop(transforms, playerPos);
            //_teamPool.PoolPop(transforms);
        }
    }

    /// <summary>
    /// Poolのオブジェクトをどこで使うかを決めるメソッド
    /// </summary>
    private void TeamPop(Transform[] teamPos, Transform playerPos)
    {
        foreach (var n in teamPos)
        {
            if (!n.gameObject.activeSelf)
            {
                n.gameObject.SetActive(true);
               // _teamPool.PoolPop(n, playerPos);
                return;
            }
        }

        Debug.LogError("基底より多く使おうとしています。");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayercCntroller>(out PlayercCntroller playercCntroller))
        {
            //Generator(playercCntroller.TeamPos, playercCntroller.transform);

            RandomTransform(playercCntroller.RangeLeft,
                playercCntroller.RangeRight,
                playercCntroller.transform);
        }
    }

    private void RandomTransform(Transform rangeLeft, Transform RrangeRight, Transform playr)
    {
        for (int i = 0; i < _teamNum; i++)
        {
            var x = Random.Range(rangeLeft.position.x, RrangeRight.position.x);
            var z = Random.Range(rangeLeft.position.z, RrangeRight.position.z);
            _teamPool.PoolPop(new Vector3(x, 0, z), playr);
        }
    }
}
