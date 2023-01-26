using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField, Tooltip("左右の移動スピード")]
    private float _horizontalMoveSpeed = 5f;
    [SerializeField, Tooltip("前方向の移動スピード")]
    private float _forwardMoveSpeed = 3f;

    private Vector3 _moveDir = default;
    public Vector3 MoveDir { get => _moveDir; set => _moveDir = value; }

    private Rigidbody _rb;
    private Transform _transform;
    
    public void Init(Rigidbody rb, Transform transform)
    {
        _rb = rb;
        _transform = transform;

    }
    /// <summary>
    /// インプットシステムから受け取った入力でプレイヤーを左右に動かす。
    /// </summary>
    public void HorizontalMove()
    {
        _rb.velocity = new Vector3(_horizontalMoveSpeed * _moveDir.x,
            _rb.velocity.y,
            _rb.velocity.z);
    }

    /// <summary>
    /// プレイヤーの前方向に自動で移動する。
    /// </summary>
    public void ForwardMove()
    {
        _transform.Translate(Vector3.forward * Time.fixedDeltaTime * _forwardMoveSpeed);
    }
}
