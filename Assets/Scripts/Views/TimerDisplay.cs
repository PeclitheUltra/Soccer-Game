using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private RectTransform _timerBar, _timerBackground;
    [SerializeField] private float _minimalBarWidth;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private GameManager _gameManager;

    private void OnEnable()
    {
        StartCoroutine(ManageTime());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator ManageTime()
    {
        while (true)
        {
            UpdateDisplay();
            yield return new WaitForSeconds(1f);
        }
    }

    private void UpdateDisplay()
    {
        float timePassed = _gameManager.TimePerRound - _gameManager.TimeLeft;
        float timeLeft = _gameManager.TimePerRound - timePassed;
        _timerText.text = $"{TimeSpan.FromSeconds(timeLeft):mm\\:ss}";
        _timerBar.sizeDelta =
            new Vector2(Mathf.Lerp(_minimalBarWidth, _timerBackground.sizeDelta.x, timePassed / _gameManager.TimePerRound),
                _timerBar.sizeDelta.y);
    }
}
