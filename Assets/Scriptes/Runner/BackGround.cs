using UnityEngine;

public class BackGround : MonoBehaviour
{
    private Rigidbody2D Rb;
    [SerializeField] private float SpeedMove;
    [SerializeField] private GameObject NeighboringBackGround;
    private const float LengthObject = 24.95884f;
    private const float LeftBorder = -25.2f;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Time.fixedDeltaTime = 0.02f;
        Rb.gravityScale = 0;
        InvokeRepeating(nameof(Velocity), 0, 1);
    }
    private void FixedUpdate()
    {
        Teleport();
        Move();
    }

    private void Move() => Rb.velocity = Vector2.left * SpeedMove;

    private void Velocity() => SpeedMove += 0.03333333334f;
    
    private void Teleport()
    {
        if (gameObject.transform.position.x <= LeftBorder)
            gameObject.transform.position = new Vector2(NeighboringBackGround.transform.position.x + LengthObject, NeighboringBackGround.transform.position.y);
    }
}
