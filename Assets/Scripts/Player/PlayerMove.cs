using UnityEngine;

[System.Serializable]
public class PlayerMove
{
    [SerializeField, Tooltip("���E�̈ړ��X�s�[�h")]
    private float _horizontalMoveSpeed = 5f;
    [SerializeField, Tooltip("�O�����̈ړ��X�s�[�h")]
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
    /// �C���v�b�g�V�X�e������󂯎�������͂Ńv���C���[�����E�ɓ������B
    /// </summary>
    public void HorizontalMove()
    {
        _rb.velocity = new Vector3(_horizontalMoveSpeed * _moveDir.x,
            _rb.velocity.y,
            _rb.velocity.z);
    }

    /// <summary>
    /// �v���C���[�̑O�����Ɏ����ňړ�����B
    /// </summary>
    public void ForwardMove()
    {
        _transform.Translate(Vector3.forward * Time.fixedDeltaTime * _forwardMoveSpeed);
    }
}
