using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    List<GameObject> _pool = new();

    [SerializeField, Tooltip("�v�[���T�C�Y")]
    int _poolSize = 100;

    [SerializeField, Tooltip("Pool�ɓ����N���X")]
    GameObject _poolObject;

    private void Start()
    {
        GameObject poolObjeck = null;
        //Pool�̃T�C�Y���I�u�W�F�N�g�𐶐�
        for (int i = 0; i < _poolSize; i++)
        {
            poolObjeck = Instantiate(_poolObject);
            poolObjeck.gameObject.SetActive(false);
            _pool.Add(poolObjeck);
        }
    }

    /// <summary>
    /// �I�u�W�F�N�g������������������g�p����
    /// </summary>
    public void PoolPop(Vector3 playerpos)
    {
        foreach (var pool in _pool)
        {
            //��A�N�e�B�u��Object����������
            if (!pool.gameObject.activeSelf)
            {
                pool.gameObject.SetActive(true);
                pool.gameObject.transform.position = playerpos;
                return;
            }
        }

        //Pool����Ȏ��Ɏ��s�����B
        GameObject poolObjeck = Instantiate(_poolObject);
        poolObjeck.gameObject.SetActive(false);
        _pool.Add(poolObjeck);
    }
}
