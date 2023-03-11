using UnityEngine;
using UniRx;

public class EnemyPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("Viewクラス")]
    private EnemyView _view;

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
            .Skip(1)//初期化を飛ばす
            .Subscribe(x => _view.HealthSlider(x))
            .AddTo(this);
    }
}
