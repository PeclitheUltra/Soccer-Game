using System;
using DG.Tweening;
using UnityEngine;

public class CollectableBall : MonoBehaviour
{
    public Action<CollectableBall> BallFinishedCollecting;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _collectTime;
    private Sequence _tweener;
    private BootsMovement _boots;
    
    private void CreateTweenSequence()
    {
        _tweener = DOTween.Sequence();
        _tweener.Append(transform.DOMoveX(0, _collectTime).SetEase(Ease.InBack));
        _tweener.Join(transform.DOMoveY(2f, _collectTime).SetEase(Ease.OutSine));
        _tweener.Join(transform.DOScale(.5f, _collectTime).SetEase(Ease.OutSine));
        _tweener.Join(_renderer.DOFade(0, _collectTime / 2).SetDelay(_collectTime / 2));
        _tweener.OnComplete(() =>
        {
            SignalBus.Scored?.Invoke();
            BallFinishedCollecting?.Invoke(this);
        });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent<BootsMovement>(out _boots))
        {
            SignalBus.HitABall?.Invoke();
            CreateTweenSequence();
        }
    }

    public void Appear()
    {
        transform.localScale = Vector3.one * .5f;
        transform.DOScale(1, .3f);
        _renderer.color = new Color(1,1,1,0);
        _renderer.DOFade(1, .3f);
    }
}
