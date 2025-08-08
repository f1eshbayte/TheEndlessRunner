using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RestartButtonAnimate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _gameOverText;
    [SerializeField] private Text _gameOverTextComponent;
    
    private Color _origColor;
    private void Start()
    {
        _origColor = _gameOverTextComponent.color;
    }

    private Tween _shakeTween;
    private Tween _colorTween;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_gameOverText == null || _gameOverTextComponent == null) 
            return;

        // Если дрожание уже идёт — не создаём новый
        if (_shakeTween == null || !_shakeTween.IsActive())
        {
            _shakeTween = _gameOverText
                .DOLocalRotate(new Vector3(0, 0, 4), 0.03f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine)
                .SetUpdate(true);
        }

        // Цвет меняем один раз
        if (_colorTween == null || !_colorTween.IsActive())
        {
            _colorTween = _gameOverTextComponent
                .DOColor(Color.red, 0.3f)
                .SetUpdate(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_shakeTween != null && _shakeTween.IsActive())
        {
            _shakeTween.Kill();
            _shakeTween = null;
        }
        if (_colorTween != null && _colorTween.IsActive())
        {
            _colorTween.Kill();
            _colorTween = null;
        }

        _gameOverText.localRotation = Quaternion.identity;
        _gameOverTextComponent.color = _origColor; // сброс цвета
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }
}
