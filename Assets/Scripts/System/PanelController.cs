using UnityEngine;
using DG.Tweening;

public class PanelController : MonoBehaviour
{
    [SerializeField, Tooltip("�I�[�f�B�I�\�[�X")]
    private AudioSource _audio;

    private void OnEnable()
    {
        //panel�����������ɏo��
        transform.DOScale(5, 0.5f);
        _audio.Play();
    }
}
