using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObjectPool : MonoBehaviour
{
    List<PoolObject> _list = new();

    [SerializeField, Tooltip("プールサイズ")]
    int _poolSize = 100;
    [SerializeField]
    PoolObject _poolObject;

    private void Start()
    {
        PoolObject poolObjeck = null;
        //Poolのサイズ分オブジェクトを生成
        for (int i = 0; i < _poolSize; i++)
        {
            poolObjeck = Instantiate(_poolObject);
            poolObjeck.gameObject.SetActive(false);
            _list.Add(poolObjeck);
        }
    }

    /// <summary>
    /// オブジェクトをに実行するためのメソッド
    /// </summary>
    public void PoolPop(Transform gunTransform)
    {

        foreach (var pool in _list)
        {
            if (pool.gameObject.activeSelf == false)
            {
                pool.gameObject.SetActive(true);
                float testz = Random.Range(-1, -4);
                float testx = Random.Range(-2, 2);
               // pool.V3 = 

                return;
            }
        }

        //Poolが空な時に実行される。
        PoolObject poolObjeck = Instantiate(_poolObject);
        poolObjeck.gameObject.SetActive(false);
        _list.Add(poolObjeck);
    }

    /// <summary>
    /// オブジェクトの使用が終わった時に実行するメソッド
    /// </summary>
    public void PoolPush(PoolObject poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
}
