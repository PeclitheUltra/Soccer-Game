using System.Text.RegularExpressions;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class WinPrompt : MonoBehaviour
{
    [SerializeField] private CanvasGroup _cvg;
    [SerializeField] private TextMeshProUGUI _prompt;
    [SerializeField] private TMP_InputField _input;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private ScreensManager _screensManager;
    
    private void OnEnable()
    {
        _cvg.alpha = 0;
        _cvg.DOFade(1, .3f);
        transform.localScale= Vector3.one * .8f;
        transform.DOScale(1, .3f);
        _prompt.text = Regex.Replace(_prompt.text, @"[0123456789]+", _gameManager.Score.ToString());
    }

    public void Continue()
    {
        if (_input.text == string.Empty)
            return;
        _cvg.DOFade(0, .3f).OnComplete(() => gameObject.SetActive(false));
        SignalBus.PlayerFinished?.Invoke(_input.text, _gameManager.Score);
        _screensManager.CloseGameplay();
    }
}
