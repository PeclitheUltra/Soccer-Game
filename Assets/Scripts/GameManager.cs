using Cysharp.Threading.Tasks;
using UnityEngine;
#pragma warning disable 4014

public class GameManager : MonoBehaviour
{
    public float TimePerRound => _timePerRound;
    public float TimeLeft { get; private set; }
    public int Score { get; private set; }

    [SerializeField] private GameObject[] _maps;
    [SerializeField] private float _timePerRound, _appearDelay;
    [SerializeField] private GameObject _enableOnVictoryGO;
    private bool _isPlaying = false;
    private GameObject _currentMap;

    private void Start()
    {
        SignalBus.Scored += AddScore;
    }

    public void StartGameButton(int map)
    {
        StartGame(map);
    }

    private async UniTaskVoid StartGame(int map)
    {
        await UniTask.Delay((int)(_appearDelay * 1000));
        SignalBus.GameStarted?.Invoke();
        _currentMap = Instantiate(_maps[map], transform.position, Quaternion.identity, transform);
        _isPlaying = true;
        TimeLeft = _timePerRound;
        Score = 0;
    }

    private void Update()
    {
        if (!_isPlaying)
            return;
        ManageTime();
    }

    private void ManageTime()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft < 0)
        {
            EndGame();
        }
    }

    public void AddScore()
    {
        Score++;
    }

    public void EndGame()
    {
        _isPlaying = false;
        Destroy(_currentMap);
        SignalBus.GameEnded.Invoke();
        _enableOnVictoryGO.SetActive(true);
    }
}
