using UnityEngine;
using UniRx;

public class CastleController : MonoBehaviour, IAddDamage
{
    /// <summary>
    /// 城のヒットポイント
    /// </summary>
    private ReactiveProperty<int> _health = new();

    public IReadOnlyReactiveProperty<int> Health => _health;

    [SerializeField, Tooltip("最大ヒットポイント")]
    private int _maxHealth = 20;

    public int MaxHealth => _maxHealth;

    void Start()
    {
        _health.Value = _maxHealth;
    }

    public void AddDamage()
    {
        _health.Value--;

        if (_health.Value <= 0)
        {
            PauseManager.Instance.Pause();
            StageData.AddClearStageIndex(StageData.CurrentStageIndex);
        }
    }
}
