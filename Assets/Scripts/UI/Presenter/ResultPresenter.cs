using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ResultPresenter : MonoBehaviour
{
    [SerializeField]
    private CastleController _castleController;

    [SerializeField]
    private CannonController _cannonController;

    [SerializeField]
    private ResultView _resultView;

    private void Start()
    {
        GameOver();
        Clear();
    }

    /// <summary>
    /// healthが0になったときにサブスクライブされる
    /// </summary>
    private void Clear()
    {
        _castleController.Health
            .Skip(1)
            .Where(x => x <= 0)
            .Subscribe(_ => _resultView.Result(ResultType.Clear))
            .AddTo(this);
    }

    private void GameOver()
    {
        _cannonController.GameOver
            .Subscribe(_ => _resultView.Result(ResultType.GameOver))
            .AddTo(this);
    }
}
