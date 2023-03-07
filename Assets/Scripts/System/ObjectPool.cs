using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    List<GameObject> _pool = new();

    [SerializeField, Tooltip("プールサイズ")]
    int _poolSize = 100;

    [SerializeField, Tooltip("Poolに入れるクラス")]
    GameObject _poolObject;

    private void Start()
    {
        GameObject poolObjeck = null;
        //Poolのサイズ分オブジェクトを生成
        for (int i = 0; i < _poolSize; i++)
        {
            poolObjeck = Instantiate(_poolObject);
            poolObjeck.gameObject.SetActive(false);
            _pool.Add(poolObjeck);
        }
    }

    /// <summary>
    /// オブジェクトを検索し見つかったら使用する
    /// </summary>
    public void PoolPop(Vector3 playerpos)
    {
        foreach (var pool in _pool)
        {
            //非アクティブのObjectを検索する
            if (!pool.gameObject.activeSelf)
            {
                pool.gameObject.SetActive(true);
                pool.gameObject.transform.position = playerpos;
                return;
            }
        }

        //Poolが空な時に実行される。
        GameObject poolObjeck = Instantiate(_poolObject);
        poolObjeck.gameObject.SetActive(false);
        _pool.Add(poolObjeck);
    }
}
