using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GimmickPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("ViewƒNƒ‰ƒX")]
    private GimmickView _view;

    [SerializeField]
    private WallGimmickController _gimmickModel;

    void Start()
    {
        GimmickCountObserver();
    }

    private void GimmickCountObserver()
    {
        _gimmickModel.DestroyCount
            .Subscribe(count => _view.GimmickCountText(count));
    }
}
