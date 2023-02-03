using System.Collections.Generic;
using UnityEngine;

public class PlayercCntroller : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動")]
    private PlayerMove _playerMove;
    [SerializeField, Tooltip("チームを生成する場所")]
    private Transform[] _teamPos;

    public Transform _test;

    public Transform[] TeamPos => _teamPos;
    public PlayerMove PlayerMove => _playerMove;

    private Rigidbody _rb;
    private Vector2 _dir = new Vector2(0, -5);
    public Vector2 Dir { get => _dir; set => _dir = value; }

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
