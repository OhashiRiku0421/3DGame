using UnityEngine;

[System.Serializable]
public class EnemyData
{
    [SerializeField, Tooltip("�G�l�~�[�̈ړ����x")]
    private float _moveSpeed = 3f;

    private GameObject _enemy;
    private Transform _transform;

    public void Init(GameObject enemy)
    {
        _enemy = enemy;
        _transform = enemy.transform;
    }
    
    /// <summary>
    /// �G�l�~�[�̈ړ�����
    /// </summary>
    public void Move()
    {
        _transform.Translate(Vector3.forward * Time.fixedDeltaTime * _moveSpeed);
    }

    /// <summary>
    /// �G�l�~�[��Pool�ɖ߂�
    /// </summary>
    public void Disable()
    {
        _enemy.SetActive(false);
    }
}
