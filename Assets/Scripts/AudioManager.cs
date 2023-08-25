using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _start, _finish;
    [SerializeField] private AudioClip[] _kick, _hit;
    
    private void Awake()
    {
        Instance = this;
        SignalBus.GameEnded += PlayFinish;
        SignalBus.Scored += PlayHit;
        SignalBus.GameStarted += PlayStart;
    }

    private void PlayStart()
    {
        _source.PlayOneShot(_start);
    }

    private void PlayFinish()
    {
        _source.PlayOneShot(_finish);
    }
    
    public void PlayKick()
    {
        _source.PlayOneShot(_kick[Random.Range(0, _kick.Length)]);
    }

    private void PlayHit()
    {
        _source.PlayOneShot(_hit[Random.Range(0, _hit.Length)]);
    }
}
