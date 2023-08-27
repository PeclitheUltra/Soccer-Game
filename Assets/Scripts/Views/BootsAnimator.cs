using UnityEngine;

public class BootsAnimator : MonoBehaviour
{
    [SerializeField] private BootsMovement _movement;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _animSpeed, _animDelta;
    
    private void Update()
    {
        var movementVector = _movement.DesiredMovement;
        if (movementVector.x > 0)
        {
            _renderer.flipX = true;
        }
        else if (movementVector.x < 0)
        {
            _renderer.flipX = false;
        }

        if (movementVector.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.Euler(0,0, Mathf.Sin(Time.time * Mathf.Deg2Rad * _animSpeed) * _animDelta);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    
}
