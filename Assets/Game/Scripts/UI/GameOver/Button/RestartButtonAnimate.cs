using UnityEngine;
using UnityEngine.EventSystems;

public class RestartButtonAnimate : BaseButtonAnimate
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!CanAnimate()) return;

        AnimateShakeRotate();
        AnimateColor(Color.red);
    }
}