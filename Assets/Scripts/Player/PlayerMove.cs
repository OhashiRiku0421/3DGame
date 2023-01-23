using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField]
    private float _horizontalMoveSpeed = 5f;
    [SerializeField]
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

    public void HorizontalMove()
    {
        _rb.velocity = new Vector3(_horizontalMoveSpeed * _moveDir.x,
            _rb.velocity.y,
            _rb.velocity.z);
    }

    public void ForwardMove()
    {
        _transform.Translate(Vector3.forward * Time.deltaTime * _forwardMoveSpeed);
    }
}
