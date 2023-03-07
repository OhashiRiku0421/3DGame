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

    [SerializeField, Tooltip("クリアのPanel")]
    private GameObject _clear;

    public int MaxHealth => _maxHealth;

    void Start()
    {
        _health.Value = _maxHealth;
        Clear();
    }

    public void AddDamage()
    {
        _health.Value--;
    }

    /// <summary>
    /// healthが0になったときにサブスクライブされる
    /// </summary>
    private void Clear()
    {
        _health
            .Where(x => x <= 0)
            .Subscribe(_ => GameManager.Instance.GameClear(_clear))
            .AddTo(this);
    }
        
}
