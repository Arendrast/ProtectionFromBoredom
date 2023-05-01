using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonMoveLeftAndroidCosmos : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsButtonPressed;
    public void OnPointerDown(PointerEventData EventData) => IsButtonPressed = true;
    public void OnPointerUp(PointerEventData EventData) => IsButtonPressed = false;
    
}