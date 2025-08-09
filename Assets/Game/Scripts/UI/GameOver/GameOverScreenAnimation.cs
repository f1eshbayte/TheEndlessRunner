using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverScreenAnimation : GameOverlayScreen
{
    [SerializeField] private float _durationOfScalingAnimation = 0.5f;
    [SerializeField] private float _initialScale = 0f;
    [SerializeField] private float _firstTargetScale = 0.8f;
    [SerializeField] private float _secondTargetScale = 0.83f;
    [SerializeField] private float _secondScaleDuration = 0.06f;
    [SerializeField] private int _secondScaleLoops = 3;
    [SerializeField] private float _intervalAfterAnimation = 0.1f;
    
    private RectTransform _rectTransform;

    protected override void Start()
    {
        base.Start();
        _rectTransform = GetComponent<RectTransform>();
    }

    protected override void PlayShowAnimation()
    {
        _rectTransform.localScale = Vector3.one * _initialScale;
        _rectTransform.DOKill();

        var seq = DOTween.Sequence();
        seq.Append(_rectTransform
            .DOScale(Vector3.one * _firstTargetScale, _durationOfScalingAnimation)
            .SetEase(Ease.OutBack)
        );
        seq.Append(_rectTransform
            .DOScale(Vector3.one * _secondTargetScale, _secondScaleDuration)
            .SetEase(Ease.InOutSine)
            .SetLoops(_secondScaleLoops, LoopType.Yoyo)
        );
        seq.AppendInterval(_intervalAfterAnimation);

        seq.SetUpdate(true);
        seq.Play();
    }
}