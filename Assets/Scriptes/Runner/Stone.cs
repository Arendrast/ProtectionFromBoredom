using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Stone : MonoBehaviour
{
    [SerializeField] private GameObject _stoneOnePrefab, _stoneTwoPrefab, _stoneThreePrefab, _stoneFourPrefab;
    
    private List<GameObject> StoneList = new List<GameObject>();

    private GameObject _stoneOne, _stoneTwo, _stoneThree, _stoneFour;
    
    private const float _onethSpeedofStone = 3.5f, _twothSpeedofStone = 3f, _threethSpeedofStone = 2.5f;
    private const float _timeIntervalBetweenUpdateTimeSpawn = 60;
    private const float _rightBorder = 12.5f;
    private const float _downBorder = -4f;
    private const float _upBorder = 1f;
    private float _timeSpawn = 4f;

    private Quaternion _randomRotation = Quaternion.Euler(0, 0, 360);
    
    private Vector2 _spawnPosition = new Vector2(12.3f, 0);


    private void Awake()
    {
        CreateStones();
        StartCoroutine(UpdateTimeSpawn());
        StartCoroutine(UpdatePositionStone());
    }

    private void CreateStone(ref GameObject stone, GameObject prefab) => stone = Instantiate(prefab, _spawnPosition, Quaternion.identity);

    private void CreateStones()
    {
        CreateStone(ref _stoneOne, _stoneOnePrefab);
        CreateStone(ref _stoneTwo, _stoneTwoPrefab);
        CreateStone(ref _stoneThree, _stoneThreePrefab);
        CreateStone(ref _stoneFour, _stoneFourPrefab);
        StoneList.Add(_stoneOne);
        StoneList.Add(_stoneTwo);
        StoneList.Add(_stoneThree);
        StoneList.Add(_stoneFour);
    }
    
    
    private IEnumerator UpdateTimeSpawn()
    {
        yield return new WaitForSeconds(_timeIntervalBetweenUpdateTimeSpawn);

        _timeSpawn = _onethSpeedofStone;

        yield return new WaitForSeconds(_timeIntervalBetweenUpdateTimeSpawn);

        _timeSpawn = _twothSpeedofStone;

        yield return new WaitForSeconds(_timeIntervalBetweenUpdateTimeSpawn);

        _timeSpawn = _threethSpeedofStone;
    }

    private IEnumerator UpdatePositionStone()
    {
        yield return new WaitForSeconds(_timeSpawn);
        var currentStone = StoneList[Random.Range(0, StoneList.Count - 1)];
        currentStone.transform.position = new Vector2(_rightBorder, Random.Range(_downBorder, _upBorder));
        currentStone.transform.rotation = _randomRotation;
        StartCoroutine(UpdatePositionStone());
    }
}
