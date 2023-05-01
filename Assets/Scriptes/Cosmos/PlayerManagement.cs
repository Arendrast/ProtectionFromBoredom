using UnityEngine;


public class PlayerManagement : MonoBehaviour
{
    private const float Speed = 2.5f;
    public Vector2 FlightDirection;
    private Rigidbody2D Rb;
    private const KeyCode ButtonRight = KeyCode.D;
    private const KeyCode ButtonLeft = KeyCode.A;
    private bool IsPressedButtonRight;
    private bool IsPressedButtonLeft;

    [SerializeField] private ButtonMoveLeftAndroidCosmos ButtonLeftOnAndroid;
    [SerializeField] private ButtonMoveRightAndroidCosmos ButtonRightOnAndroid;
    [SerializeField] private GameObject ManagementOnAndroid;
    
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.freezeRotation = true;
        Rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    private void Update() => ManagementDirection();
    private void FixedUpdate() => Move();
    private void Move() => Rb.velocity = new Vector2(FlightDirection.x * Speed, Rb.velocity.y);
    private void ManagementDirection()
    {
        if (!ManagementOnAndroid.activeInHierarchy)
        {
            if (Input.GetKey(ButtonRight) && !IsPressedButtonLeft)
            {
                FlightDirection = Vector2.right;
                IsPressedButtonRight = true;
            }
            
            if (Input.GetKeyUp(ButtonRight))
                IsPressedButtonRight = false;

            if (Input.GetKey(ButtonLeft) && !IsPressedButtonRight)
            {
                FlightDirection = Vector2.left;
                IsPressedButtonLeft = true;
            }

            if (Input.GetKeyUp(ButtonLeft))
                IsPressedButtonLeft = false;
        }
        else
        {
            if (ButtonRightOnAndroid.IsButtonPressed && !IsPressedButtonLeft)
            {
                FlightDirection = Vector2.right;
                IsPressedButtonRight = true;
            }

            if (!ButtonRightOnAndroid.IsButtonPressed)
                IsPressedButtonRight = false;

            if (ButtonLeftOnAndroid.IsButtonPressed && !IsPressedButtonRight)
            {
                FlightDirection = Vector2.left;
                IsPressedButtonLeft = true;
            }

            if (!ButtonLeftOnAndroid.IsButtonPressed)
                IsPressedButtonLeft = false;
        }
        
        if (!IsPressedButtonLeft && !IsPressedButtonRight)
            FlightDirection = Vector2.zero;
    }
}
    