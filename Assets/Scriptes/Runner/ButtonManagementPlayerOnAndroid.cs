using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonManagementPlayerOnAndroid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Vector2 _directionVelocity;
    [SerializeField] private Rigidbody2D _playerRB;
    [SerializeField] private PlayerRunner _playerScript;
    [SerializeField] private ButtonManagementPlayerOnAndroid _scriptOtherButton;
    public bool IsButtonPressed { get; private set; }
    public void OnPointerDown(PointerEventData EventData) => IsButtonPressed = true;
    public void OnPointerUp(PointerEventData EventData) => IsButtonPressed = false;
    private void FixedUpdate() => ExecutionMovement();
    
    private void ExecutionMovement()
    {
        if (IsButtonPressed)
            _playerRB.velocity = _directionVelocity * _playerScript.Velocity;
        else if (!IsButtonPressed && !_scriptOtherButton.IsButtonPressed)
            _playerRB.velocity = Vector2.zero;
    }
}
