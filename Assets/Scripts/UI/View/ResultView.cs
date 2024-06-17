using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ResultView : MonoBehaviour
{
    [SerializeField]
    private GameObject _clearPanel;

    [SerializeField]
    private GameObject _gameOverPanel;

    [SerializeField, Tooltip("オーディオソース")]
    private AudioSource _clearAudio;

    [SerializeField]
    private AudioSource _gameOverAudio;

    private RectTransform _transform;

    public void Result(ResultType resultType)
    {
        if(resultType == ResultType.Clear)
        {
            _transform = _clearPanel.GetComponent<RectTransform>();
            _clearPanel.SetActive(true);
            _clearAudio.Play();
        }
        else
        {
            _transform = _gameOverPanel.GetComponent<RectTransform>();
            _gameOverPanel.SetActive(true);
            _gameOverAudio.Play();
        }

        PanelControl();
    }

    private void PanelControl()
    {
        //panelをいい感じに出す
        var sequence = DOTween.Sequence();

        sequence.Append(_transform.DOScale(5.5f, 0.4f));
        sequence.Append(_transform.DOScale(5, 0.2f));
    }
}

public enum ResultType
{
    Clear,
    GameOver,
}
