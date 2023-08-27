    using DG.Tweening;
    using UnityEngine;
    using UnityEngine.UI;

    public class FadeOutAppearAnimation : MonoBehaviour
{
    [SerializeField] private Image _graphics;
    private void OnEnable()
    {
        _graphics.DOFade(0, .5f);
    }
}
