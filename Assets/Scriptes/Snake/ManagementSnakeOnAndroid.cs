using UnityEngine;

public class ManagementSnakeOnAndroid : MonoBehaviour
{

    [SerializeField] private SnakeManagement _snakeManagementScript;
    [SerializeField] private GameObject _player;
    public void ManagementVector(string button)
    {
        if (_snakeManagementScript.InputVector.x != 0 && !_snakeManagementScript.IsMove)
        {
            if (button == "Up")
                _snakeManagementScript.SetVectorMovement(Vector2.up);
            else if (button == "Down")
                _snakeManagementScript.SetVectorMovement(Vector2.down);
            
            _player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_snakeManagementScript.InputVector.y != 0 && !_snakeManagementScript.IsMove)
        {
            if (button == "Left")
                _snakeManagementScript.SetVectorMovement(Vector2.left);
            
            if (button == "Right")
                _snakeManagementScript.SetVectorMovement(Vector2.right);
            
            _player.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
