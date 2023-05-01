using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveUpAndroidRunner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rigidbody2D PlayerRigidbody;
    [SerializeField] private PlayerRunner PlayerScript;
    [SerializeField] private ButtonMoveDownAndroidRunner ButtonDownScript;
    public bool IsButtonPressed;
    public void OnPointerDown(PointerEventData EventData) => IsButtonPressed = true;
    public void OnPointerUp(PointerEventData EventData) => IsButtonPressed = false;
    private void FixedUpdate() => ExecutionMovement();
        
    private void ExecutionMovement()
    {
        if (IsButtonPressed)
            PlayerRigidbody.velocity = Vector2.up * PlayerScript.Velocity * 1.5f;
        else if (!IsButtonPressed && !ButtonDownScript.IsButtonPressed)
            PlayerRigidbody.velocity = Vector2.zero;
    }
}
