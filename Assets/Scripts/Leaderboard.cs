using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Leaderboard : MonoBehaviour
{
    private Dictionary<string, int> _records;
    private static string RECORDS_KEY = "Records";

    private void Awake()
    {
        InitializeRecords();
        SignalBus.PlayerFinished += AddName;
    }

    public Dictionary<string, int> GetLeaderboard() => _records;

    private void InitializeRecords()
    {
        if (PlayerPrefs.HasKey(RECORDS_KEY))
        {
            Load();
        }
        else
        {
            _records = new Dictionary<string, int>();
        }
    }

    private void AddName(string name, int score)
    {
        if (_records.ContainsKey(name))
        {
            if (_records[name] < score)
                _records[name] = score;
        }
        else
        {
            _records.Add(name, score);
        }
        Save();
    }

    private void Load()
    {
        _records = JsonConvert.DeserializeObject<Dictionary<string, int>>(PlayerPrefs.GetString(RECORDS_KEY));
    }

    private void Save()
    {
        PlayerPrefs.SetString(RECORDS_KEY, JsonConvert.SerializeObject(_records));
    }
}
