using System.Linq;
using UnityEngine;

public class LeaderboardDisplay : MonoBehaviour
{
    [SerializeField] private Leaderboard _lb;
    [SerializeField] private LeaderboardEntry[] _entries;

    private void OnEnable()
    {
        var scoresSorted = _lb.GetLeaderboard().OrderByDescending(x => x.Value).ToList();
        for (int i = 0; i < _entries.Length; i++)
        {
            if (i < scoresSorted.Count)
            {
                _entries[i].Show();
                _entries[i].SetPlayer(scoresSorted[i].Key, scoresSorted[i].Value);
            }
            else
            {
                _entries[i].Hide();
            }
        }
    }
}
