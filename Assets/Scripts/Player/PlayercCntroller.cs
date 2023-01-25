using System.Collections.Generic;
using UnityEngine;

public class PlayercCntroller : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動")]
    private PlayerMove _playerMove;
    [SerializeField, Tooltip("チームを生成する場所")]
    private List<Transform> _teamPos = new List<Transform>();

    public List<Transform> TeamPos => _teamPos;
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
