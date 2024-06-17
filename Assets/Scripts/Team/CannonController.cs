using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening.Core.Easing;

public class CannonController : MonoBehaviour
{
    [SerializeField, Tooltip("ミイラを生成する座標")]
    private Transform _muzzle;

    [SerializeField, Tooltip("オブジェクトプール")]
    private ObjectPool _pool;

    [SerializeField, Tooltip("生成できる最大数")]
    private int _maxCount = 30;

    public int MaxCount => _maxCount;

    private ReactiveProperty<int> _count = new();

    private Subject<Unit> _gameOver = new();

    public ISubject<Unit> GameOver => _gameOver;
    public IReactiveProperty<int> Count => _count;

    private Vector3 _dir;

    private void Start()
    {
        _count.Value = _maxCount;
    }

    /// <summary>
    /// buttonを押すと生成される
    /// </summary>
    public void OnAttack()
    {
        if(_count.Value > 0)
        {
            _dir = _muzzle.position;
            _pool.PoolPop(_dir);
            _count.Value--;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IAddDamage>(out IAddDamage addDamage))
        {
            //接触したオブジェクトがIAddDamageを継承していたら以下を実行する
            _gameOver.OnNext(Unit.Default);
            PauseManager.Instance.Pause();
        }
    }
}
