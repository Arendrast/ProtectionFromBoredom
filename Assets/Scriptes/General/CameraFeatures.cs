using UnityEngine;

public class CameraFeatures : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    public Vector2 LowerLeftPointOfCamera { get; private set; }
    public Vector2 LowerRightPointOfCamera { get; private set; }
    public Vector2 UpperRightPointOfCamera { get; private set; }
    public Vector2 UpperLeftPointOfCamera { get; private set; }
    public float CameraLength { get; private set; }
    public float CameraHeight { get; private set; }

    private void Awake()
    {
        GetPositionOfPointsOfCamera();
        GetCameraScale();
    } 
    private void GetPositionOfPointsOfCamera()
    {
        LowerLeftPointOfCamera = _camera.ScreenToWorldPoint(new Vector2(0f, 0f));
        LowerRightPointOfCamera = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth, 0f));
        UpperRightPointOfCamera = _camera.ScreenToWorldPoint(new Vector2(_camera.pixelWidth, _camera.pixelHeight));
        UpperLeftPointOfCamera = _camera.ScreenToWorldPoint(new Vector2(0, _camera.pixelHeight));
    }

    private void GetCameraScale()
    {
        CameraLength = Mathf.Abs(LowerLeftPointOfCamera.x) + Mathf.Abs(LowerRightPointOfCamera.x);
        CameraHeight = Mathf.Abs(LowerLeftPointOfCamera.y) + Mathf.Abs(UpperLeftPointOfCamera.y);
    }
}
