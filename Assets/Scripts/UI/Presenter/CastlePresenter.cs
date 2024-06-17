using UnityEngine;
using UniRx;

public class CastlePresenter : MonoBehaviour
{
    [SerializeField, Tooltip("View�N���X")]
    private CastleView _view;

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
            .Subscribe(x => _view.HealthSlider(x))
            .AddTo(this);
    }
}
