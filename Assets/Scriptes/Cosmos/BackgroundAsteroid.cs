using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundAsteroid : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 _currentVector;
    
    private SpawnPoints _spawnPoints;
    private SpriteRenderer _spriteRenderer;
    private StorageOfAsteroidTypes _storageOfAsteroidTypes;
    
    private bool _isCanTouch = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _storageOfAsteroidTypes = FindObjectOfType<StorageOfAsteroidTypes>();
        _spawnPoints = FindObjectOfType<SpawnPoints>();
    }

    private void FixedUpdate() => Move();

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (_isCanTouch)
        {
            ChangeVectorOfDirection(col, "LeftPointSpawn", 0.1f, 1f, -0.9f, 1f);
            
            ChangeVectorOfDirection(col, "RightPointSpawn", -0.9f, -0.1f, -0.9f, 1f);
            
            ChangeVectorOfDirection(col, "UpPointSpawn", -0.9f, 0.9f, -0.9f, -0.1f);
            
            ChangeVectorOfDirection(col, "DownPointSpawn", -0.9f, 1f, 0.1f, 1f);
            
            ChangeVectorOfDirection(col, "UpperLeftCornerPointSpawn", 0.1f, 0.9f, -0.9f, -0.1f);
            
            ChangeVectorOfDirection(col, "UpperRightCornerPointSpawn", -0.9f, -0.1f, -0.9f, -0.1f);
            
            ChangeVectorOfDirection(col, "LowerLeftCornerPointSpawn", 0.1f, 0.9f, 0.1f, 0.9f);
            
            ChangeVectorOfDirection(col, "LowerRightCornerPointSpawn", -0.9f, -0.1f, 0.1f, 0.9f);
        }
    }

    private void ChangeVectorOfDirection(Collider2D col, string pointSpawn, float minValueX, float maxValueX, float minValueY, float maxValueY)
    {
        if (col.gameObject.CompareTag(pointSpawn))
        {
            _currentVector = new Vector2(Random.Range(minValueX, maxValueX), Random.Range(minValueY, maxValueY));
            _isCanTouch = false;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("ZoneExitOfAsteroid"))
            UpdateAsteroidParameters();
    }

    private void UpdateAsteroidParameters()
    {
        _currentVector = Vector2.zero;
        _spriteRenderer.sprite = _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid[Random.Range(0, _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid.Count)];
        var RandomValue = Random.Range(0.05f, 0.1f);
        transform.localScale = new Vector2(RandomValue, RandomValue);
        transform.position = _spawnPoints.ListSpawnPoints[Random.Range(0, _spawnPoints.ListSpawnPoints.Count)].transform.position;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        _isCanTouch = true;
    }
    private void Move()
    {
        if (_currentVector != Vector2.zero)
            _rb.velocity = _currentVector;
    }
}
