using UnityEngine;

public class ManagementOnAndroidSnake : MonoBehaviour
{

    [SerializeField] private SnakeManagement SnakeManagementScript;
    [SerializeField] private GameObject Player;
    public void ManagementVector(string Button)
    {
        if (SnakeManagementScript.InputVector.x != 0 && !SnakeManagementScript.IsMove)
        {
            if (Button == "Up")
            {
                SnakeManagementScript.InputVector = Vector2.up;
                SnakeManagementScript.IsMove = true;
            }
            else if (Button == "Down")
            {
                SnakeManagementScript.InputVector = Vector2.down;
                SnakeManagementScript.IsMove = true;
            }
            Player.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (SnakeManagementScript.InputVector.y != 0 && !SnakeManagementScript.IsMove)
        {
            if (Button == "Left")
            {
                SnakeManagementScript.InputVector = Vector2.left;
                SnakeManagementScript.IsMove = true;
            }
            if (Button == "Right")
            {
                SnakeManagementScript.InputVector = Vector2.right;
                SnakeManagementScript.IsMove = true;
            }
            Player.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
}
