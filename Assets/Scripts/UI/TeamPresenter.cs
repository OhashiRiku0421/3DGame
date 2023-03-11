using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TeamPresenter : MonoBehaviour
{
    [SerializeField, Tooltip("View�N���X")]
    private TeamView _view;

    [SerializeField, Tooltip("Model�N���X")]
    private CannonController _cannonModel;

    private void Start()
    {
        CountObserver();
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
