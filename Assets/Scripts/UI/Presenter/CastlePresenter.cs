using UnityEngine;
using UniRx;

public class CastlePresenter : MonoBehaviour
{
    [SerializeField, Tooltip("Viewクラス")]
    private CastleView _view;

    [SerializeField, Tooltip("Modelクラス")]
    private CastleController _castleModel;

    private void Start()
    {
        _view.Init(_castleModel.MaxHealth);
        HealthObserver();
    }

    /// <summary>
    /// 城のヒットポイントを監視し、値が変化したらサブスクライブする
    /// </summary>
    private void HealthObserver()
    {
        _castleModel.Health
            .Subscribe(x => _view.HealthSlider(x))
            .AddTo(this);
    }
}
