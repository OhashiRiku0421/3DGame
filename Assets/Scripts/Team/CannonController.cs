using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using DG.Tweening.Core.Easing;

public class CannonController : MonoBehaviour
{
    [SerializeField, Tooltip("�~�C���𐶐�������W")]
    private Transform _muzzle;

    [SerializeField, Tooltip("�I�u�W�F�N�g�v�[��")]
    private ObjectPool _pool;

    [SerializeField, Tooltip("�����ł���ő吔")]
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
    /// button�������Ɛ��������
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
            //�ڐG�����I�u�W�F�N�g��IAddDamage���p�����Ă�����ȉ������s����
            _gameOver.OnNext(Unit.Default);
            PauseManager.Instance.Pause();
        }
    }
}
