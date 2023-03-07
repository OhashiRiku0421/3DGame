using System.Collections;
using UnityEngine;

public class TeamController : MonoBehaviour, IPause
{

    [SerializeField, Tooltip("�`�[���𐶐�����͈�")]
    private Transform _rangeLeft;
    public Transform RangeLeft => _rangeLeft;

    [SerializeField, Tooltip("�`�[���𐶐�����͈�")]
    private Transform _rangeRight;
    public Transform RangeRight => _rangeRight;

    [SerializeField, Tooltip("�~�C���̈ړ����x")]
    private float _moveSpeed = 4f;

    private bool _isPause = false;

    [SerializeField]
    private AudioSource _audio;

    private void Start()
    {
        PauseManager.Instance.Entry(gameObject);
    }

    private void Update()
    {
        if(!_isPause)
        {
            Move();
        }
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    private void Move()
    {
        transform.Translate(Vector3.forward * Time.fixedDeltaTime * _moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IAddDamage>(out IAddDamage addDamage))
        {
            addDamage.AddDamage();
            _audio.Play();
            StartCoroutine(AudioInterval());
        }
    }

    /// <summary>
    /// �����o�Ă����Pool�ɖ߂��Ȃ�
    /// </summary>
    IEnumerator AudioInterval()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
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
        PauseManager.Instance.Lift(gameObject);
    }
}
