using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnimationController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Button‚ÉG‚ê‚Ä‚¢‚é‚Æ‚«‘å‚«‚­‚È‚é
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1.2f, 1.2f), 0.2f);
    }

    /// <summary>
    /// button‚©‚ç—£‚ê‚½‚çŒ³‚É–ß‚é
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1f, 1f), 0.2f);
    }
}