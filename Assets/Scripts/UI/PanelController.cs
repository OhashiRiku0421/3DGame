using UnityEngine;
using DG.Tweening;

public class PanelController : MonoBehaviour
{
    [SerializeField, Tooltip("オーディオソース")]
    private AudioSource _audio;

    private void OnEnable()
    {
        //panelをいい感じに出す
        transform.DOScale(5, 0.5f);
        _audio.Play();
    }
}
