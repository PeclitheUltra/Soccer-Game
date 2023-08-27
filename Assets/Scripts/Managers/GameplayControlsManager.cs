using UnityEngine;

public class GameplayControlsManager : MonoBehaviour
{
    public static GameplayControlsManager Instance;
    public Vector2 Movement { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void AddMovement(Vector2 dir)
    {
        Movement += dir;
    }
}
