using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour, IPause
{
    [SerializeField, Tooltip("�G�l�~�[�𐶐�����͈�")]
    private Transform _rangeLeft;

    [SerializeField, Tooltip("�G�l�~�[�𐶐�����͈�")]
    private Transform _rangeRight;

    [SerializeField, Tooltip("�I�u�W�F�N�g�v�[��")]
    private ObjectPool _pool;

    [SerializeField, Tooltip("��x�ɐ������鐔")]
    private int _enemyNum = 10;

    [SerializeField,Tooltip("�����̃C���^�[�o��")]
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
    /// ���߂�ꂽ�͈͂̒��̃����_���ȍ��W���擾
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
    /// �G�l�~�[�𐶐�����C���^�[�o��
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
