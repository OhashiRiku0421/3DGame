using UnityEngine;
using UniRx;

public class CastleController : MonoBehaviour, IAddDamage
{
    /// <summary>
    /// ��̃q�b�g�|�C���g
    /// </summary>
    private ReactiveProperty<int> _health = new();

    public IReadOnlyReactiveProperty<int> Health => _health;

    [SerializeField, Tooltip("�ő�q�b�g�|�C���g")]
    private int _maxHealth = 20;

    [SerializeField, Tooltip("�N���A��Panel")]
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
    /// health��0�ɂȂ����Ƃ��ɃT�u�X�N���C�u�����
    /// </summary>
    private void Clear()
    {
        _health
            .Where(x => x <= 0)
            .Subscribe(_ => GameManager.Instance.GameClear(_clear))
            .AddTo(this);
    }
        
}
