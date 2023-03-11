using UnityEngine;
using UniRx;

public class EnemyPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("View�N���X")]
    private EnemyView _view;

    [SerializeField, Tooltip("Model�N���X")]
    private CastleController _castleModel;

    private void Start()
    {
        _view.Init(_castleModel.MaxHealth);
        HealthObserver();
    }

    /// <summary>
    /// ��̃q�b�g�|�C���g���Ď����A�l���ω�������T�u�X�N���C�u����
    /// </summary>
    private void HealthObserver()
    {
        _castleModel.Health
            .Skip(1)//���������΂�
            .Subscribe(x => _view.HealthSlider(x))
            .AddTo(this);
    }
}
