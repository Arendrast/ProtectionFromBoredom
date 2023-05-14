using UnityEngine;

public class AntiBugRectangle : MonoBehaviour
{
    [SerializeField] private CameraFeatures _cameraFeaturesScript;
    
    [SerializeField] private GameObject _RectanglePrefab;

    private GameObject _antiBugRectangle;

    private void Awake()
    {
        CreateAntiBugRectangle();
        UpdatePositionOfAntiBugRectangle();
        SetScaleOfAntiBugRectangle();
    }
    private void CreateAntiBugRectangle() => _antiBugRectangle = Instantiate(_RectanglePrefab);
    private void UpdatePositionOfAntiBugRectangle() => _antiBugRectangle.transform.position = Vector2.zero;
    private void SetScaleOfAntiBugRectangle() => _antiBugRectangle.gameObject.transform.localScale = new Vector2(_cameraFeaturesScript.CameraLength, _cameraFeaturesScript.CameraHeight);
    
}
