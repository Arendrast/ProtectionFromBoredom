using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAsteroid : MonoBehaviour
{
    private List<GameObject> _listAsteroid = new List<GameObject>();
    
    private StorageOfAsteroidTypes _storageOfAsteroidTypes;
    private StorageOfPrefabOfAsteroid _storageOfPrefabOfAsteroid;
    private const float _upBorder = 14;
    private const float _leftBorder = -12;
    private const float _rightBorder = 12;
    private float _timeSpawn = 5f;
    private const float _timeIntervalBetweenUpdateTimeSpawn = 60;
    private const float _onethSpeedofAsteroid = 3.5f, _twothSpeedofAsteroid = 3f, _threethSpeedofAsteroid = 2.5f;

    private void Awake()
    {
        _storageOfAsteroidTypes = GetComponent<StorageOfAsteroidTypes>();
        _storageOfPrefabOfAsteroid = GetComponent<StorageOfPrefabOfAsteroid>();
        StartCoroutine(UpdateTimeSpawn());
        StartCoroutine(UpdatePosition());
    }

    private void Start() => Spawn();

    private IEnumerator UpdateTimeSpawn()
    {
        yield return new WaitForSeconds(_timeIntervalBetweenUpdateTimeSpawn);
        _timeSpawn = _onethSpeedofAsteroid;
        yield return new WaitForSeconds(_timeIntervalBetweenUpdateTimeSpawn);
        _timeSpawn = _twothSpeedofAsteroid;
        yield return new WaitForSeconds(_timeIntervalBetweenUpdateTimeSpawn);
        _timeSpawn = _threethSpeedofAsteroid;
    }

    private void Spawn()
    {
        for (var I = 0; I < 4; I++)
        {
            var currentAsteroid = Instantiate(_storageOfPrefabOfAsteroid.Asteroid, new Vector2(100, 100), Quaternion.identity);
            var spriteRendererOfCurrentAsteroid = currentAsteroid.GetComponent<SpriteRenderer>();
            var randomValue = Random.Range(0, _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid.Count);
            spriteRendererOfCurrentAsteroid.sprite = _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid[randomValue];
            var scriptOfCurrentAsteroid = currentAsteroid.GetComponent<Asteroid>();
            scriptOfCurrentAsteroid.OffAllColliderOnAsteroid();
            scriptOfCurrentAsteroid.ListColliderOfAsteroid[randomValue].enabled = true;
            scriptOfCurrentAsteroid.ListColliderOfAsteroid[randomValue].isTrigger = true;
            currentAsteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            currentAsteroid.transform.localScale = new Vector2(Random.Range(0.75f, 1.51f), Random.Range(0.75f, 1.51f));
            currentAsteroid.tag = "Enemy";
            _listAsteroid.Add(currentAsteroid);
        }
    }

    private IEnumerator UpdatePosition()
    {
        for (var I = 0; I < 4; I++)
        {
            yield return new WaitForSeconds(_timeSpawn);
            var currentAsteroid = _listAsteroid[I];
            var spriteRendererOfCurrentAsteroid = currentAsteroid.GetComponent<SpriteRenderer>();
            var randomValue = Random.Range(0, _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid.Count);
            spriteRendererOfCurrentAsteroid.sprite = _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid[randomValue];
            var scriptOfCurrentAsteroid = currentAsteroid.GetComponent<Asteroid>();
            scriptOfCurrentAsteroid.OffAllColliderOnAsteroid();
            scriptOfCurrentAsteroid.ListColliderOfAsteroid[randomValue].enabled = true;
            scriptOfCurrentAsteroid.ListColliderOfAsteroid[randomValue].isTrigger = true;
            currentAsteroid.transform.localScale = new Vector2(Random.Range(0.75f, 1.51f), Random.Range(0.75f, 1.51f));
            currentAsteroid.transform.position = new Vector2(Random.Range(_leftBorder, _rightBorder), _upBorder);
        }
        StartCoroutine(UpdatePosition());
    }
}

