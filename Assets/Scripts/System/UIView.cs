using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIView : MonoBehaviour
{
    [SerializeField, Tooltip("スライダー")]
    private Slider _slider;

    [SerializeField, Tooltip("ミイラの残り")]
    private Text _countText;

    public void Init(int maxHealth)
    {
        _slider.maxValue = maxHealth;
    }

    /// <summary>
    /// 減ったヒットポイント分をスライダーに指定秒数かけて変化する
    /// </summary>
    public void HealthSlider(float value)
    {
        DOTween.To(() => _slider.value,
                n => _slider.value = n,
                value,
                0.5f);
    }

    /// <summary>
    /// テキストに現在のカウントを代入する
    /// </summary>
    public void CountView(int count)
    {
        _countText.text = count.ToString();
    }

}
