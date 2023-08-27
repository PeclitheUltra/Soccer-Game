using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BootsFX : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _flipSource;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite[] _hitFXSprites;
    private void OnEnable()
    {
        SignalBus.HitABall += PlayAnimation;
        _renderer.color = new Color(1,1,1,0);
    }

    private void PlayAnimation()
    {
        _renderer.sprite = _hitFXSprites[Random.Range(0, _hitFXSprites.Length)];
        _renderer.DOFade(1, .05f);
        _renderer.transform.localScale = Vector3.one * .8f;
        _renderer.transform.DOScale(1, .1f);
        _renderer.DOFade(0, .15f).SetDelay(.05f);
    }

    private void Update()
    {
        _renderer.flipY = _flipSource.flipX;
    }

    private void OnDisable()
    {
        SignalBus.HitABall -= PlayAnimation;
    }
}
