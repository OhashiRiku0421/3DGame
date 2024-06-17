using System.Collections;
using UnityEngine;

public class TeamController : MonoBehaviour, IPause
{

    [SerializeField, Tooltip("チームを生成する範囲")]
    private Transform _rangeLeft;
    public Transform RangeLeft => _rangeLeft;

    [SerializeField, Tooltip("チームを生成する範囲")]
    private Transform _rangeRight;
    public Transform RangeRight => _rangeRight;

    [SerializeField]
    private TeamData _teamData;

    private bool _isPause = false;

    [SerializeField]
    private AudioSource _audio;

    [SerializeField]
    private GameObject _model;

    private void Start()
    {
        PauseManager.Instance.Entry(this);
        _teamData.Init(transform);
    }

    private void FixedUpdate()
    {
        if (!_isPause)
        {
            _teamData.Move();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<IAddDamage>(out IAddDamage addDamage))
        {
            addDamage.AddDamage();
            _audio.Play();
            _model.SetActive(false);
            StartCoroutine(AudioInterval());
        }
    }

    /// <summary>
    /// 音が出ている間Poolに戻さない
    /// </summary>
    IEnumerator AudioInterval()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
        _model.SetActive(true);
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
