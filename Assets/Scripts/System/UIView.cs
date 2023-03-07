using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIView : MonoBehaviour
{
    [SerializeField, Tooltip("�X���C�_�[")]
    private Slider _slider;

    [SerializeField, Tooltip("�~�C���̎c��")]
    private Text _countText;

    public void Init(int maxHealth)
    {
        _slider.maxValue = maxHealth;
    }

    /// <summary>
    /// �������q�b�g�|�C���g�����X���C�_�[�Ɏw��b�������ĕω�����
    /// </summary>
    public void HealthSlider(float value)
    {
        DOTween.To(() => _slider.value,
                n => _slider.value = n,
                value,
                0.5f);
    }

    /// <summary>
    /// �e�L�X�g�Ɍ��݂̃J�E���g��������
    /// </summary>
    public void CountView(int count)
    {
        _countText.text = count.ToString();
    }

}
