using UnityEngine;
using DG.Tweening;

public class PanelController : MonoBehaviour
{
    [SerializeField, Tooltip("�I�[�f�B�I�\�[�X")]
    private AudioSource _audio;

    [SerializeField]
    private RectTransform _transform;

    private void OnEnable()
    {
        //panel�����������ɏo��
        var sequence = DOTween.Sequence();

        sequence.AppendCallback(() => _audio.Play());
        sequence.Append(_transform.DOScale(5.5f, 0.4f));
        sequence.Append(_transform.DOScale(5, 0.2f));
        
    }
}
