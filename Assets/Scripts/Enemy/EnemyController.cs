using UnityEngine;

public class EnemyController : MonoBehaviour, IAddDamage, IPause
{
    [SerializeField, Tooltip("エネミーのデータクラス")]
    private EnemyData _date;

    private bool _isPause = false;

    private void Start()
    {
        _date.Init(gameObject);
        PauseManager.Instance.Entry(this);
    }
    private void FixedUpdate()
    {
        if (!_isPause)
        {
            _date.Move();
        }
    }

    public void AddDamage()
    {
        _date.Disable();
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
