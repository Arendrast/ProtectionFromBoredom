using UnityEngine;

public class MoveStars : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private float _speedMove;
    [SerializeField] private GameObject _neighboringBackGround;
    private const float _fixedDeltaTime = 0.02f;
    private const float _lengthObject = 24.95884f;
    private const float _leftBorder = -25.2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        Time.fixedDeltaTime = _fixedDeltaTime;
        _rb.gravityScale = 0;
        InvokeRepeating(nameof(UpdateVelocity), 0, 1);
    }
    private void FixedUpdate()
    {
        UpdatePosition();
        Move();
    }

    private void Move() => _rb.velocity = Vector2.left * _speedMove;

    private void UpdateVelocity() => _speedMove += 0.03333333334f;
    
    private void UpdatePosition()
    {
        if (gameObject.transform.position.x <= _leftBorder)
            gameObject.transform.position = new Vector2(_neighboringBackGround.transform.position.x + _lengthObject, _neighboringBackGround.transform.position.y);
    }
}
