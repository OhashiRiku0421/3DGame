using UnityEngine;
using UniRx;

public class WallGimmickController : MonoBehaviour, IAddDamage
{
    [SerializeField, Tooltip("Wall�̍ő�q�b�g�|�C���g")]
    private int _maxCount = 5;

    private ReactiveProperty<int> _destroyCount = new();

    public IReadOnlyReactiveProperty<int> DestroyCount => _destroyCount;

    private void Start()
    {
        _destroyCount.Value = _maxCount;
    }

    public void AddDamage()
    {
        _destroyCount.Value--;
        if(_destroyCount.Value <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
