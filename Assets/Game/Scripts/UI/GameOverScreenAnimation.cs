using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverScreenAnimation : GameOverlayScreen
{
    [SerializeField] private float _durationOfScalingAnimation = 0.5f;
    
    private RectTransform _rectTransform;

    protected override void Start()
    {
        base.Start();
        _rectTransform = GetComponent<RectTransform>();
    }

    protected override void PlayShowAnimation()
    {
        _rectTransform.localScale = Vector3.zero;
        _rectTransform.DOKill();

        var seq = DOTween.Sequence();
        seq.Append(_rectTransform
            .DOScale(Vector3.one * 0.8f, _durationOfScalingAnimation)
            .SetEase(Ease.OutBack)
        );
        seq.Append(_rectTransform
            .DOScale(Vector3.one * 0.83f, 0.06f)
            .SetEase(Ease.InOutSine)
            .SetLoops(3, LoopType.Yoyo)
        );
        seq.AppendInterval(0.1f);

        seq.SetUpdate(true);
        seq.Play();
    }

    
}