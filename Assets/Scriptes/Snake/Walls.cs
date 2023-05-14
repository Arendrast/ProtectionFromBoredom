using UnityEngine;

public class Walls : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;

    private CameraFeatures _cameraFeatures;
    
    private GameObject _upperWall, _lowerWall, _leftWall, _rightWall;

    private const float _heightVerticalWall = 15f, _widthHorizontalWall = 15f;
    
    private Vector2 _positionOfPointOfMiddleOfUpperBorderOfCamera, _positionOfPointOfMiddleOfLowerBorderOfCamera, _positionOfPointOfOfMiddleOfLeftBorderOfCamera, _positionOfPointOfMiddleOfRightBorderOfCamera;

    private void Start()
    {
        _cameraFeatures = GetComponent<CameraFeatures>();
        
        SetVectorsOfMiddlePointOfCamera();
        CreateWalls();
        SetSizesWalls();
    }
    
    private void CreateWall(ref GameObject wall, Vector2 wallPosition) => wall = Instantiate(_wallPrefab, wallPosition, Quaternion.identity);

    private void CreateWalls()
    {
        CreateWall(ref _upperWall, _positionOfPointOfMiddleOfUpperBorderOfCamera);
        CreateWall(ref _lowerWall, _positionOfPointOfMiddleOfLowerBorderOfCamera);
        CreateWall(ref _leftWall, _positionOfPointOfOfMiddleOfLeftBorderOfCamera);
        CreateWall(ref _rightWall, _positionOfPointOfMiddleOfRightBorderOfCamera);
    }

    private void SetVectorOfMiddlePointOfCamera(ref Vector2 positionOfPoint, float positionX = 0, float positionY = 0) => positionOfPoint = new Vector2(positionX, positionY);

    private void SetVectorsOfMiddlePointOfCamera()
    {
        SetVectorOfMiddlePointOfCamera(ref _positionOfPointOfMiddleOfUpperBorderOfCamera, positionY: _cameraFeatures.UpperRightPointOfCamera.y + _heightVerticalWall / 2);
        SetVectorOfMiddlePointOfCamera(ref _positionOfPointOfMiddleOfLowerBorderOfCamera, positionY: _cameraFeatures.LowerRightPointOfCamera.y - _heightVerticalWall / 2);
        SetVectorOfMiddlePointOfCamera(ref _positionOfPointOfMiddleOfRightBorderOfCamera, _cameraFeatures.UpperRightPointOfCamera.x + _widthHorizontalWall / 2);
        SetVectorOfMiddlePointOfCamera(ref  _positionOfPointOfOfMiddleOfLeftBorderOfCamera, -_cameraFeatures.LowerRightPointOfCamera.x - _widthHorizontalWall / 2);
    }

    private void SetSizeWall(ref GameObject wall, bool isVerticalBorder, float scaleX = 0, float scaleY = 0)
    {
        float widthWall, heightWall;

        if (!isVerticalBorder)
        {
            widthWall = _cameraFeatures.CameraLength;
            heightWall = _heightVerticalWall;
        }
        else
        {
            widthWall = _widthHorizontalWall;
            heightWall = _cameraFeatures.CameraHeight;
        }

        scaleX = widthWall;
        scaleY = heightWall;
        wall.transform.localScale = new Vector2(scaleX, scaleY);
    }

    private void SetSizesWalls()
    {
        SetSizeWall(ref _upperWall, false, scaleY: _heightVerticalWall);
        SetSizeWall(ref _lowerWall, false, scaleY: _heightVerticalWall);
        SetSizeWall(ref _rightWall, true, _widthHorizontalWall);
        SetSizeWall(ref _leftWall, true, _widthHorizontalWall);
    }
}
