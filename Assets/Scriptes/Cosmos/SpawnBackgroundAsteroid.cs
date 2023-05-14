using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBackgroundAsteroid : MonoBehaviour
{
    private StorageOfPrefabOfAsteroid _storageOfPrefabOfAsteroid;
    private StorageOfAsteroidTypes _storageOfAsteroidTypes;
    private SpawnPoints _spawnPoints;
    private void Start()
    {
        GetLinks();
        SpawnAsteroid();   
    }

    private void GetLinks()
    {
        _storageOfAsteroidTypes = GetComponent<StorageOfAsteroidTypes>();
        _storageOfPrefabOfAsteroid = GetComponent<StorageOfPrefabOfAsteroid>();
        _spawnPoints = GetComponent<SpawnPoints>();
    }
    private void SpawnAsteroid()
    {
        for (var I = 0; I < 8; I++)
        { 
            var currentAsteroid = Instantiate(_storageOfPrefabOfAsteroid.BackgroundAsteroid);
           var CurrentSpriteRenderer = currentAsteroid.GetComponent<SpriteRenderer>();
           CurrentSpriteRenderer.sprite = _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid[Random.Range(0, _storageOfAsteroidTypes.ListSpritesTypeOfAsteroid.Count)];
           currentAsteroid.transform.position = _spawnPoints.ListSpawnPoints[I].transform.position;
           currentAsteroid.transform.localScale = new Vector2(0.1f, 0.1f);
        }
    }
}
