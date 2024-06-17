using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TeamPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("Viewクラス")]
    private TeamView _view;

    [SerializeField, Tooltip("Modelクラス")]
    private CannonController _cannonModel;

    private void Start()
    {
        CountObserver();
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
