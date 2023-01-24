using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObjectPool : MonoBehaviour
{
    List<PoolObject> _list = new();

    [SerializeField, Tooltip("�v�[���T�C�Y")]
    int _poolSize = 100;
    [SerializeField]
    PoolObject _poolObject;

    private void Start()
    {
        PoolObject poolObjeck = null;
        //Pool�̃T�C�Y���I�u�W�F�N�g�𐶐�
        for (int i = 0; i < _poolSize; i++)
        {
            poolObjeck = Instantiate(_poolObject);
            poolObjeck.gameObject.SetActive(false);
            _list.Add(poolObjeck);
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g���Ɏ��s���邽�߂̃��\�b�h
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

        //Pool����Ȏ��Ɏ��s�����B
        PoolObject poolObjeck = Instantiate(_poolObject);
        poolObjeck.gameObject.SetActive(false);
        _list.Add(poolObjeck);
    }

    /// <summary>
    /// �I�u�W�F�N�g�̎g�p���I��������Ɏ��s���郁�\�b�h
    /// </summary>
    public void PoolPush(PoolObject poolObject)
    {
        poolObject.gameObject.SetActive(false);
    }
}
