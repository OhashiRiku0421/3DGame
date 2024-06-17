using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour, IPause
{
    [SerializeField, Tooltip("エネミーを生成する範囲")]
    private Transform _rangeLeft;

    [SerializeField, Tooltip("エネミーを生成する範囲")]
    private Transform _rangeRight;

    [SerializeField, Tooltip("オブジェクトプール")]
    private ObjectPool _pool;

    [SerializeField, Tooltip("一度に生成する数")]
    private int _enemyNum = 10;

    [SerializeField,Tooltip("生成のインターバル")]
    private float _attackInterval = 5f;

    private bool _isAttack = true;
    private bool _isPause = false;

    private void Start()
    {
        _isAttack = true;
        StartCoroutine(AttackInterval());
        PauseManager.Instance.Entry(this);
    }

    private void Update()
    {
        if(!_isPause)
        {
            RandomGenerator();
        }
    }

    /// <summary>
    /// 決められた範囲の中のランダムな座標を取得
    /// </summary>
    private void RandomGenerator()
    {
        if(!_isAttack)
        {
            for (int i = 0; i < _enemyNum; i++)
            {
                var x = Random.Range(_rangeLeft.position.x, _rangeRight.position.x);
                var z = Random.Range(_rangeLeft.position.z, _rangeRight.position.z);
                _pool.PoolPop(new Vector3(x, -1, z));
            }
            _isAttack = true;
            StartCoroutine(AttackInterval());
        }
    }

    /// <summary>
    /// エネミーを生成するインターバル
    /// </summary>
    IEnumerator AttackInterval()
    {
        yield return new WaitForSeconds(_attackInterval);
        _isAttack = false;
    }

    public void Pause()
    {
        _isPause = true;
    }

    public void Resume()
    {
        _isPause = false;
    }

    private void OnDestroy()
    {
        PauseManager.Instance.Lift(this);
    }
}
