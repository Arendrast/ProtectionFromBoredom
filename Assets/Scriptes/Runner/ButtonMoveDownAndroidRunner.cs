using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveDownAndroidRunner : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Rigidbody2D PlayerRigidbody;
    [SerializeField] private PlayerRunner PlayerScript;
    [SerializeField] private ButtonMoveUpAndroidRunner ButtonUpScript;
    public bool IsButtonPressed;
    public void OnPointerDown(PointerEventData EventData) => IsButtonPressed = true;
    public void OnPointerUp(PointerEventData EventData) => IsButtonPressed = false;
    private void FixedUpdate() => ExecutionMovement();
    
    private void ExecutionMovement()
    {
        if (IsButtonPressed)
            PlayerRigidbody.velocity = Vector2.down * PlayerScript.Velocity * 1.5f;
        else if (!IsButtonPressed && !ButtonUpScript.IsButtonPressed)
            PlayerRigidbody.velocity = Vector2.zero;
    }
}
