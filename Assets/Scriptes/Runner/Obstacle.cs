using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D _rb;
    private float _speedMove = 12;
    private const float _leftBorder = -14f;
    private const float _rightBorder = 12.4f;
    private bool _isMove;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
        InvokeRepeating(nameof(UpdateVelocity), 0, 1);
        _rb.velocity = Vector2.zero;
    }
    private void FixedUpdate() => Move();
    private void Update()
    {
        StopMove();
        MoveAgain();
    }

    private void UpdateVelocity() => _speedMove += 0.03333333334f;
    

    private void Move() { if (_isMove) _rb.velocity = Vector2.left * _speedMove; }

    private void StopMove()
    {
        if (gameObject.transform.position.x <= _leftBorder)
        {
            _isMove = false;
            _rb.velocity = Vector2.zero;
        }
    }
    private void MoveAgain() { if (gameObject.transform.position.x >= _rightBorder) _isMove = true; }
}
