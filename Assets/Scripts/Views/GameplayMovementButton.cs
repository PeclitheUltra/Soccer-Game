using UnityEngine;
using UnityEngine.EventSystems;

public class GameplayMovementButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _movement;

    public void OnPointerDown(PointerEventData eventData)
    {
        GameplayControlsManager.Instance.AddMovement(_movement);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        GameplayControlsManager.Instance.AddMovement(-_movement);
    }
}
