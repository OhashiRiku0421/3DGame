using UnityEngine;
using UniRx;

public class UIPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("View�N���X")]
    private UIView _view;

    [SerializeField, Tooltip("Model�N���X")]
    private CastleController _castleModel;

    [SerializeField, Tooltip("Model�N���X")]
    private CannonController _cannonModel;

    private void Start()
    {
        _view.Init(_castleModel.MaxHealth);
        HealthObserver();
        CountObserver();
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

    /// <summary>
    /// �~�C���̒e�����Ď����A�l���ω�������T�u�X�N���C�u����
    /// </summary>
    private void CountObserver()
    {
        _cannonModel.Count
            .Subscribe(x => _view.CountView(x))
            .AddTo(this);
    }
}
