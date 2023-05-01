using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonShootingCosmos : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsButtonPressed;
    public void OnPointerDown(PointerEventData EventData) => IsButtonPressed = true;
    public void OnPointerUp(PointerEventData EventData) => IsButtonPressed = false;
}
