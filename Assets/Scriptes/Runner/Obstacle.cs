using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody2D Rb;
    private float SpeedMove = 12;
    private const float LeftBorder = -14f;
    private const float RightBorder = 12.4f;
    private bool IsMove;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.gravityScale = 0;
        InvokeRepeating(nameof(UpdateVelocity), 0, 1);
        Rb.velocity = Vector2.zero;
    }
    private void FixedUpdate() => Move();
    private void Update()
    {
        StopMove();
        MoveAgain();
    }

    private void UpdateVelocity() => SpeedMove += 0.03333333334f;
    

    private void Move() { if (IsMove) Rb.velocity = Vector2.left * SpeedMove; }

    private void StopMove()
    {
        if (gameObject.transform.position.x <= LeftBorder)
        {
            IsMove = false;
            Rb.velocity = Vector2.zero;
        }
    }
    private void MoveAgain() { if (gameObject.transform.position.x >= RightBorder) IsMove = true; }
}
