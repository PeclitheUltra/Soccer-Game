using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
#pragma warning disable 4014

public class ScreensManager : MonoBehaviour
{
    [SerializeField] private RectTransform _menu, _results, _policy, _gameCards, _gameplay, _canvas, _splash;
    [SerializeField] private float _transitionTime;
    private float _canvasWidth => _canvas.sizeDelta.x;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        SwitchWindows(_splash, _menu);
    }

    public void OpenResults()
    {
        SwitchWindows(_menu, _results);
    }

    public void CloseResults()
    {
        SwitchWindows(_results, _menu);
    }

    public void OpenPolicy()
    {
        SwitchWindows(_menu, _policy);
    }

    public void ClosePolicy()
    {
        SwitchWindows(_policy, _menu);
    }

    public void OpenGameCards()
    {
        SwitchWindows(_menu, _gameCards);
    }

    public void CloseGameCards()
    {
        SwitchWindows(_gameCards, _menu);
    }

    public void OpenGameplay()
    {
        SwitchWindows(_gameCards, _gameplay);
    }

    public void CloseGameplay()
    {
        SwitchWindows(_gameplay, _gameCards);
    }

    private async UniTaskVoid SwitchWindows(RectTransform from, RectTransform to)
    {
        from.DOLocalMoveX(-_canvasWidth, _transitionTime).OnComplete(() => ResetWindow(from)).SetEase(Ease.InSine);
        await UniTask.Delay(200);
        to.transform.localPosition = new Vector3(_canvasWidth, 0, 0);
        to.gameObject.SetActive(true);
        to.DOLocalMoveX(0, _transitionTime).SetEase(Ease.OutSine);
    }

    private void ResetWindow(RectTransform window)
    {
        window.gameObject.SetActive(false);
        window.transform.position = Vector3.zero;
    }
}
