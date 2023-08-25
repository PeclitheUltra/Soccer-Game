using UnityEngine;

public class BootsMovement : MonoBehaviour
{
    public Vector2 DesiredMovement => GetInput().normalized;
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

    private Vector2 GetInput()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
