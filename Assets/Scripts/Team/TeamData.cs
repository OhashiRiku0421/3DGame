using UnityEngine;

[System.Serializable]
public class TeamData
{
    [SerializeField, Tooltip("ミイラの移動速度")]
    private float _moveSpeed = 4f;

    private Transform _transform;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init(Transform transform)
    {
        _transform = transform;
    }

    /// <summary>
    /// 移動の処理
    /// </summary>
    public void Move()
    {
        _transform.Translate(Vector3.forward * Time.fixedDeltaTime * _moveSpeed);
    }
}
