using UnityEngine;
using UnityEngine.InputSystem;

public class PlayercCntroller : MonoBehaviour
{
    private Vector2 _moveDir = default;
    private Rigidbody _rb;
    [SerializeField]
    private PlayerInput _input;

    public PlayerInput Input  => _input;

    public　Vector2 MoveDir { get => _moveDir; set => _moveDir = new Vector2(); }



    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        //Input();
    }
    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(_moveDir.x, 0) * 3;
    }

    private void Update()
    {

    }
}
