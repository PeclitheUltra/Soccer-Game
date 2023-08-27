using UnityEngine;

public class BootsMovement : MonoBehaviour
{
    public Vector2 DesiredMovement => Application.isMobilePlatform ? GameplayControlsManager.Instance.Movement.normalized : (GameplayControlsManager.Instance.Movement.normalized + GetInputPC().normalized);
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private bool _canMove = true;

    private void FixedUpdate()
    {
        if (_canMove)
        {
            _rigidbody.MovePosition(_rigidbody.position + DesiredMovement * (Time.fixedDeltaTime * _speed));
        }
    }

    private Vector2 GetInputPC()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
