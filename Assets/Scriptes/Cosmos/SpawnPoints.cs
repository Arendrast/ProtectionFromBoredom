using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public List<GameObject> ListSpawnPoints { get; private set; } = new List<GameObject>();
    
    [SerializeField] private GameObject _rectanglePrefab;

    private CameraFeatures _cameraFeatures;
    
    private const float DefaultHeight = 2;
    private const float DefaultWidth = 2;
    
    private GameObject _leftPointSpawn, _rightPointSpawn, _upPointSpawn, _downPointSpawn;

    private GameObject _upperLeftCornerPointSpawn,
        _upperRightCornerPointSpawn,
        _lowerLeftCornerPointSpawn,
        _lowerRightCornerPointSpawn;

    private void Awake()
    {
        _cameraFeatures = FindObjectOfType<CameraFeatures>();
        
        SettingRectangle();
        CreateSpawnPoints();
        ZoneExitOfAsteroid();   
    }
    

    private void SettingRectangle()
    {
        var SpriteRendererRectangle = _rectanglePrefab.GetComponent<SpriteRenderer>();
        SpriteRendererRectangle.color = new Color(0, 0, 0, 0);
        if (_rectanglePrefab.GetComponent<BoxCollider2D>() == null)
        {
            var boxCollider2D = _rectanglePrefab.AddComponent<BoxCollider2D>();
            boxCollider2D.isTrigger = true;   
        }
    }

    private void CreateSpawnPoint(ref GameObject point, float scaleX, float scaleY, float positionX, float positionY, string tagOfPoint)
    {
        point =  Instantiate(_rectanglePrefab);  
        ListSpawnPoints.Add(point);
        point.transform.localScale = new Vector2(scaleX, scaleY);
        point.transform.position = new Vector2(positionX, positionY);
        point.tag = tagOfPoint;
    }

    private void CreateSpawnPoints()
    {
        var offsetMultiplier = 1.2f;
        
        CreateSpawnPoint(ref _leftPointSpawn, DefaultWidth, _cameraFeatures.CameraHeight / 2, _cameraFeatures.UpperLeftPointOfCamera.x - DefaultWidth / 2, 0, "LeftPointSpawn");
        CreateSpawnPoint(ref _leftPointSpawn, DefaultWidth, _cameraFeatures.CameraHeight / 2, _cameraFeatures.UpperRightPointOfCamera.x + DefaultWidth / 2, 0, "RightPointSpawn");
        CreateSpawnPoint(ref _upPointSpawn, _cameraFeatures.CameraLength / 2, DefaultHeight, 0, _cameraFeatures.UpperRightPointOfCamera.y + DefaultHeight / 2, "UpPointSpawn");
        CreateSpawnPoint(ref _downPointSpawn, _cameraFeatures.CameraLength / 2, DefaultHeight, 0, _cameraFeatures.LowerLeftPointOfCamera.y - DefaultHeight / 2, "DownPointSpawn");

        CreateSpawnPoint(ref _upperLeftCornerPointSpawn, _cameraFeatures.CameraLength / 2, _cameraFeatures.CameraHeight / 2,_cameraFeatures.UpperLeftPointOfCamera.x * offsetMultiplier, _cameraFeatures.UpperRightPointOfCamera.y * offsetMultiplier, "UpperLeftCornerPointSpawn");
        CreateSpawnPoint(ref _upperRightCornerPointSpawn, _cameraFeatures.CameraLength / 2, _cameraFeatures.CameraHeight / 2,_cameraFeatures.UpperRightPointOfCamera.x * offsetMultiplier, _cameraFeatures.UpperRightPointOfCamera.y * offsetMultiplier, "UpperRightCornerPointSpawn");
        CreateSpawnPoint(ref _lowerLeftCornerPointSpawn, _cameraFeatures.CameraLength / 2, _cameraFeatures.CameraHeight / 2,_cameraFeatures.LowerLeftPointOfCamera.x * offsetMultiplier, _cameraFeatures.LowerLeftPointOfCamera.y * offsetMultiplier, "LowerLeftCornerPointSpawn");
        CreateSpawnPoint(ref _lowerRightCornerPointSpawn, _cameraFeatures.CameraLength / 2, _cameraFeatures.CameraHeight / 2,_cameraFeatures.LowerRightPointOfCamera.x * offsetMultiplier, _cameraFeatures.LowerRightPointOfCamera.y * offsetMultiplier, "LowerRightCornerPointSpawn");
    }

    private void ZoneExitOfAsteroid()
    {
        var ZoneExitOfAsteroid = Instantiate(_rectanglePrefab);
        ZoneExitOfAsteroid.transform.localScale = new Vector2(_cameraFeatures.CameraLength, _cameraFeatures.CameraHeight);
        ZoneExitOfAsteroid.transform.position = Vector2.zero;
        ZoneExitOfAsteroid.tag = "ZoneExitOfAsteroid";
    }
}
