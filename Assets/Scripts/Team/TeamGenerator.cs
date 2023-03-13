using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TeamGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("�K�v�ȃ`�[���̐�")]
    private int _teamNum = 2;

    [SerializeField, Tooltip("�I�u�W�F�N�g�v�[��")]
    private ObjectPool _teamPool = null;

    [SerializeField, Tooltip("�����鐔�̃e�L�X�g")]
    private Text _text;

    [SerializeField]
    private AudioSource _audio;

    private bool _isPop = false;

    private void Start()
    {
        _text.text = _teamNum.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<TeamController>(out TeamController playercCntroller) && !_isPop)
        {
            _isPop = true;
            StartCoroutine(PopInterval());
            RandomTransform(playercCntroller.RangeLeft,
                playercCntroller.RangeRight);
            _audio.Play();
        }
    }

    /// <summary>
    /// ���₷�C���^�[�o��
    /// </summary>
    IEnumerator PopInterval()
    {
        yield return new WaitForSeconds(0.3f);
        _isPop = false;
    }

    /// <summary>
    /// ���߂�ꂽ�͈͂̃����_���ȍ��W���擾
    /// </summary>
    private void RandomTransform(Transform rangeLeft, Transform rangeRight)
    {
        for (int i = 0; i < _teamNum; i++)
        {
            var x = Random.Range(rangeLeft.position.x, rangeRight.position.x);
            var z = Random.Range(rangeLeft.position.z, rangeRight.position.z);
            _teamPool.PoolPop(new Vector3(x, 0, z));
        }
    }
}
