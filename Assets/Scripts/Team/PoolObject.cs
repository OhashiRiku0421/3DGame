using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    Vector3 _v3 = new Vector3(0, 0, 0);
    public Vector3 V3 { get => _v3; set => _v3 = value; }

}
