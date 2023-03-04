using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TestMove : MonoBehaviour
{
    [SerializeField] private Vector3[] _v;

    void Start()
    {
        transform.DOPath(_v, 2);
    }

    void Update()
    {
        
    }
}
