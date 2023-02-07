using System.Collections.Generic;
using UnityEngine;

public class PlayercCntroller : MonoBehaviour
{
    [SerializeField, Tooltip("プレイヤーの移動")]
    private PlayerMove _playerMove;
    public PlayerMove PlayerMove => _playerMove;

    [SerializeField, Tooltip("チームを生成する場所")]
    private Transform[] _teamPos;
    public Transform[] TeamPos => _teamPos;

    [SerializeField, Tooltip("チームを生成する範囲")]
    private Transform _rangeLeft;
    public Transform RangeLeft => _rangeLeft;

    [SerializeField, Tooltip("チームを生成する範囲")]
    private Transform _rangeRight;
    public Transform RangeRight => _rangeRight;

    public Transform TestPos;

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
