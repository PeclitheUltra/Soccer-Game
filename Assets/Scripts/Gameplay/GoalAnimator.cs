using DG.Tweening;
using UnityEngine;

public class GoalAnimator : MonoBehaviour
{
    [SerializeField] private Material _material;

    private void OnEnable()
    {
        SignalBus.Scored += PlayAnimation;
        _material.SetFloat("_Power", 0);
    }

    private void OnDisable()
    {
        SignalBus.Scored -= PlayAnimation;
    }

    private void PlayAnimation()
    {
        _material.DOKill();
        _material.SetFloat("_Power", 0);
        _material.DOFloat(-.3f, "_Power", .15f);
        _material.DOFloat(0, "_Power", .5f).SetDelay(.15f).SetEase(Ease.OutElastic);
    }
}
