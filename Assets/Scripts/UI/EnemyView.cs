using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class EnemyView : MonoBehaviour
{
    [SerializeField, Tooltip("�X���C�_�[")]
    private Slider _slider;

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
}
