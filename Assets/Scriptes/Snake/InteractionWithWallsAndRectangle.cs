using UnityEngine;

public class InteractionWithWallsAndRectangle : MonoBehaviour
{

    [SerializeField] private SnakeManagement SnakeManagementScript;
    private Vector2 DownLeftPointCamera, UpRightPointCamera;

    private void Awake() => CalculatingCameraEndPoints();
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            var PositionX = transform.position.x;
            var PositionY = transform.position.y;
            if (gameObject.transform.position.x >= UpRightPointCamera.x && SnakeManagementScript.InputVector.x != 0 || gameObject.transform.position.x <= DownLeftPointCamera.x && SnakeManagementScript.InputVector.x != 0)
                gameObject.transform.position = new Vector2(-PositionX, PositionY);
            else if (gameObject.transform.position.y >= UpRightPointCamera.y && SnakeManagementScript.InputVector.y != 0 || gameObject.transform.position.y <= -UpRightPointCamera.y && SnakeManagementScript.InputVector.y != 0)
                gameObject.transform.position = new Vector2(PositionX, -PositionY);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AntiBagRectangle"))
            Invoke(nameof(BackSnake), 3);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AntiBagRectangle"))
            CancelInvoke(nameof(BackSnake));
    }
    private void BackSnake() => gameObject.transform.position = Vector3.zero;
    private void CalculatingCameraEndPoints()
    {
        var CameraCash = FindObjectOfType<Camera>();
        DownLeftPointCamera = CameraCash.ScreenToWorldPoint(new Vector2(0f, 0f));
        UpRightPointCamera = CameraCash.ScreenToWorldPoint(new Vector2(CameraCash.pixelWidth, CameraCash.pixelHeight));
    }
}
