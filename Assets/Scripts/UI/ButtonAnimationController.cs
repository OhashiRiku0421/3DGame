using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnimationController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private float _animSpeed = 0.2f;
    /// <summary>
    /// Buttonに触れているとき大きくなる
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1.2f, 1.2f), _animSpeed);
    }

    /// <summary>
    /// buttonから離れたら元に戻る
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1f, 1f), _animSpeed);
    }
}