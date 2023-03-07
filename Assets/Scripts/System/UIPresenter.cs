using UnityEngine;
using UniRx;

public class UIPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("Viewクラス")]
    private UIView _view;

    [SerializeField, Tooltip("Modelクラス")]
    private CastleController _castleModel;

    [SerializeField, Tooltip("Modelクラス")]
    private CannonController _cannonModel;

    private void Start()
    {
        _view.Init(_castleModel.MaxHealth);
        HealthObserver();
        CountObserver();
    }

    /// <summary>
    /// 城のヒットポイントを監視し、値が変化したらサブスクライブする
    /// </summary>
    private void HealthObserver()
    {
        _castleModel.Health
            .Skip(1)//初期化を飛ばす
            .Subscribe(x => _view.HealthSlider(x))
            .AddTo(this);
    }

    /// <summary>
    /// ミイラの弾数を監視し、値が変化したらサブスクライブする
    /// </summary>
    private void CountObserver()
    {
        _cannonModel.Count
            .Subscribe(x => _view.CountView(x))
            .AddTo(this);
    }
}
