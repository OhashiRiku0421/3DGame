using UnityEngine;

public class PlayercCntroller : MonoBehaviour
{
    [SerializeField]
    private PlayerMove _playerMove;
    public PlayerMove PlayerMove => _playerMove;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _playerMove.Init(_rb, transform);
    }

    private void FixedUpdate()
    {
        _playerMove.HorizontalMove();
        _playerMove.ForwardMove();
    }

    private void Update()
    {

    }
}
