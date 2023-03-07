using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeSystem : MonoBehaviour
{
    [SerializeField, Tooltip("Fade�̃p�l��")]
    private Image _image;

    void Start()
    {
        FadeIn();
    }

    /// <summary>
    /// �t�F�[�h�A�E�g
    /// </summary>
    public void FadeOut(string sceneName)
    {
        _image.enabled = true;
        _image.DOFade(1, 0.8f)
            .SetDelay(0.5f)
            //fadeout���I�������Ă΂��
            .OnComplete(() => SceneManager.LoadScene(sceneName));
    }

    /// <summary>
    /// �t�F�[�h�C��
    /// </summary>
    public void FadeIn()
    {
        _image.enabled = true;
        _image.DOFade(0, 1.5f)
        .SetDelay(0.5f)
        .OnComplete(() => _image.enabled = false);
    }
}
