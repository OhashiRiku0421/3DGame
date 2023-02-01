using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObjectPool : MonoBehaviour
{
    List<PoolObject> _list = new();

    [SerializeField, Tooltip("プールサイズ")]
    int _poolSize = 100;
    [SerializeField, Tooltip("Poolに入れるクラス")]
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
            //非アクティブのObjectを検索する
            if (!pool.gameObject.activeSelf)
            {
                pool.gameObject.SetActive(true);
                pool.gameObject.transform.position = gunTransform.position;
               // pool.gameObject.transform.SetParent(gunTransform);
                pool.Init(gunTransform);
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
