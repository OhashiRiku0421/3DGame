using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamObjectPool : MonoBehaviour
{
    List<PoolObject> _list = new();

    [SerializeField, Tooltip("�v�[���T�C�Y")]
    int _poolSize = 100;
    [SerializeField, Tooltip("Pool�ɓ����N���X")]
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
            //��A�N�e�B�u��Object����������
            if (!pool.gameObject.activeSelf)
            {
                pool.gameObject.SetActive(true);
                pool.gameObject.transform.position = gunTransform.position;
               // pool.gameObject.transform.SetParent(gunTransform);
                pool.Init(gunTransform);
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
