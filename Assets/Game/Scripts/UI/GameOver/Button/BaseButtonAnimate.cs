using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class BaseButtonAnimate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI Elements")]
    [SerializeField] protected RectTransform _gameOverText;
    [SerializeField] protected Text _gameOverTextComponent;

    [Header("Shake Move Settings")]
    [SerializeField] private float _moveOffsetY = 10f;      
    [SerializeField] private float _moveDuration = 0.1f;    

    [Header("Shake Rotate Settings")]
    [SerializeField] private Vector3 _rotateAngle = new Vector3(0, 0, 4f); 
    [SerializeField] private float _rotateDuration = 0.03f;                
    [SerializeField] private Ease _rotateEase = Ease.InOutSine;           

    [Header("Color Settings")]
    [SerializeField] private float _colorDuration = 0.3f; 

    protected Color _origTextColor;
    protected Tween _shakeTween;
    protected Tween _colorTween;
    protected float _origAnchorPosY;

    protected virtual void Start()
    {
        _origTextColor = _gameOverTextComponent.color;
        _origAnchorPosY = _gameOverText.anchoredPosition.y;
    }

    protected virtual void OnDisable()
    {
        _shakeTween?.Kill();
        _colorTween?.Kill();
    }

    protected bool CanAnimate()
    {
        return _gameOverText != null && _gameOverTextComponent != null;
    }

    protected void AnimateShakeMove()
    {
        if (_shakeTween == null || !_shakeTween.IsActive())
        {
            _shakeTween = _gameOverText
                .DOAnchorPosY(_origAnchorPosY - _moveOffsetY, _moveDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetUpdate(true);
        }
    }

    protected void AnimateShakeRotate()
    {
        if (_shakeTween == null || !_shakeTween.IsActive())
        {
            _shakeTween = _gameOverText
                .DOLocalRotate(_rotateAngle, _rotateDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(_rotateEase)
                .SetUpdate(true);
        }
    }

    protected void AnimateColor(Color targetColor)
    {
        if (_colorTween == null || !_colorTween.IsActive())
        {
            _colorTween = _gameOverTextComponent
                .DOColor(targetColor, _colorDuration)
                .SetUpdate(true);
        }
    }

    protected virtual void AnimateToTextExit()
    {
        _shakeTween?.Kill();
        _colorTween?.Kill();

        _shakeTween = null;
        _colorTween = null;

        _gameOverText.localRotation = Quaternion.identity;
        _gameOverTextComponent.color = _origTextColor;
        _gameOverText.anchoredPosition = new Vector2(_gameOverText.anchoredPosition.x, _origAnchorPosY);
    }
    
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        AnimateToTextExit();
    }

    public virtual void OnPointerEnter(PointerEventData eventData) { }
    public virtual void OnPointerDown(PointerEventData eventData) { }
    public virtual void OnPointerUp(PointerEventData eventData) { }
}
