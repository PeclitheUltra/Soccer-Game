using System;
using TMPro;
using UnityEngine;

public class LeaderboardEntry : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _name, _score;
    [SerializeField] private CanvasGroup _cvg;

    public void Show()
    {
        _cvg.alpha = 1;
    }
    
    public void Hide()
    {
        _cvg.alpha = 0;
    }

    public void SetPlayer(string key, int value)
    {
        _name.text = key;
        _score.text = value.ToString();
    }
}
