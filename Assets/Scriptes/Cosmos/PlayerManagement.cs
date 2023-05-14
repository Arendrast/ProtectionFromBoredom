using UnityEngine;


public class PlayerManagement : MonoBehaviour
{
    private Vector2 FlightDirection;
    
    private const float _speed = 2.5f;
    
    private Rigidbody2D _rb;
    
    private const KeyCode _buttonRight = KeyCode.D;
    private const KeyCode _buttonLeft = KeyCode.A;
    
    private bool _isPressedButtonRight;
    private bool _isPressedButtonLeft;

    [SerializeField] private ButtonMoveAndroidCosmos _buttonLeftOnAndroid;
    [SerializeField] private ButtonMoveAndroidCosmos _buttonRightOnAndroid;
    
    [SerializeField] private GameObject _managementOnAndroid;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        _rb.constraints = RigidbodyConstraints2D.FreezePositionY;
    }
    private void Update() => ManagementDirection();
    private void FixedUpdate() => Move();
    private void Move() => _rb.velocity = new Vector2(FlightDirection.x * _speed, _rb.velocity.y);
    private void ManagementDirection()
    {
        if (!_managementOnAndroid.activeInHierarchy)
        {
            if (Input.GetKey(_buttonRight) && !_isPressedButtonLeft)
                ChangeFlightDirection(Vector2.right, ref _isPressedButtonRight);

            if (Input.GetKeyUp(_buttonRight))
                _isPressedButtonRight = false;

            if (Input.GetKey(_buttonLeft) && !_isPressedButtonRight)
                ChangeFlightDirection(Vector2.left, ref _isPressedButtonLeft);

            if (Input.GetKeyUp(_buttonLeft))
                _isPressedButtonLeft = false;
        }
        else
        {
            if (_buttonRightOnAndroid.IsButtonPressed && !_isPressedButtonLeft)
                ChangeFlightDirection(Vector2.right, ref _isPressedButtonRight);

            if (!_buttonRightOnAndroid.IsButtonPressed)
                _isPressedButtonRight = false;

            if (_buttonLeftOnAndroid.IsButtonPressed && !_isPressedButtonRight)
                ChangeFlightDirection(Vector2.left, ref _isPressedButtonLeft);

            if (!_buttonLeftOnAndroid.IsButtonPressed)
                _isPressedButtonLeft = false;
        }
        
        if (!_isPressedButtonLeft && !_isPressedButtonRight)
            FlightDirection = Vector2.zero;
    }

    private void ChangeFlightDirection(Vector2 vector, ref bool isPressedButton)
    {
        FlightDirection = vector;
        isPressedButton = true;
    }
        
}
    