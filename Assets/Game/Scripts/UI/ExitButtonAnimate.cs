using System;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

public class ExitButtonAnimate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler,
    IPointerUpHandler
{
    [SerializeField] private RectTransform _gameOverText;
    [SerializeField] private Text _gameOverTextComponent;

    private Color _origColor;
    private Tween _shakeTween;
    private Tween _colorTween;

    private float _origAnchorPosY;

    private void Start()
    {
        _origColor = _gameOverTextComponent.color;
        _origAnchorPosY = _gameOverText.anchoredPosition.y; // вот тут локальная координата!
    }

    private void OnDisable()
    {
        _shakeTween.Kill();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimateToTextStart();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AnimateToTextExit();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    }

    private void AnimateToButtonStart()
    {
        
    }
    
    private void AnimateToTextStart()
    {
        if (_gameOverText == null || _gameOverTextComponent == null)
            return;

        if (_shakeTween == null || !_shakeTween.IsActive())
        {
            _shakeTween = _gameOverText
                .DOAnchorPosY(_origAnchorPosY - 10f, 0.1f) // прыгаем вниз на 10 юнитов
                .SetLoops(-1, LoopType.Yoyo)
                .SetUpdate(true);
        }

        if (_colorTween == null || !_colorTween.IsActive())
        {
            _colorTween = _gameOverTextComponent.DOColor(Color.green, 0.3f)
                .SetUpdate(true);
        }
    }

    private void AnimateToTextExit()
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
        _gameOverTextComponent.color = _origColor; 
        _gameOverText.anchoredPosition = new Vector2(_gameOverText.anchoredPosition.x, _origAnchorPosY);
    }
}