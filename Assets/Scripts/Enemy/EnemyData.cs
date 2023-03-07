using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField, Tooltip("エネミーの移動速度")]
    private float _moveSpeed = 3f;

    private GameObject _enemy;
    private Transform _transform;

    public void Init(GameObject enemy)
    {
        _enemy = enemy;
        _transform = enemy.transform;
    }
    
    /// <summary>
    /// エネミーの移動処理
    /// </summary>
    public void Move()
    {
        _transform.Translate(Vector3.forward * Time.fixedDeltaTime * _moveSpeed);
    }

    /// <summary>
    /// エネミーをPoolに戻す
    /// </summary>
    public void Disable()
    {
        _enemy.SetActive(false);
    }
}
