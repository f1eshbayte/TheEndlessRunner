using UnityEngine;
using UnityEngine.EventSystems;

public class ExitButtonAnimate : BaseButtonAnimate
{
    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (!CanAnimate()) return;

        AnimateShakeMove();
        AnimateColor(Color.green);
    }
}