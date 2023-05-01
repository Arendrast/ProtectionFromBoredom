using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpawnStone : MonoBehaviour
{
    [SerializeField] private GameObject StoneOne, StoneTwo, StoneThree, StoneFour;
    public List<GameObject> StoneList;
    private const float DownBorder = -4f;
    private const float UpBorder = 1f;
    private const float RightBorder = 12.5f;
    private float TimeSpawn = 4f;


    private void Awake()
    {
        var StoneOneInGame = Instantiate(StoneOne, new Vector2(RightBorder - 0.2f, 0), Quaternion.identity);
        StoneList.Add(StoneOneInGame);
        var StoneTwoInGame = Instantiate(StoneTwo, new Vector2(RightBorder - 0.2f, 0), Quaternion.identity);
        StoneList.Add(StoneTwoInGame);
        var StoneThreeInGame = Instantiate(StoneThree, new Vector2(RightBorder - 0.2f, 0), Quaternion.identity);
        StoneList.Add(StoneThreeInGame);
        var StoneFourInGame = Instantiate(StoneFour, new Vector2(RightBorder - 0.2f, 0), Quaternion.identity);
        StoneList.Add(StoneFourInGame);
        StartCoroutine(UpdateTimeSpawn());
        StartCoroutine(MoveStone());
    }

    private IEnumerator UpdateTimeSpawn()
    {
        yield return new WaitForSeconds(60);

        TimeSpawn = 3.5f;

        yield return new WaitForSeconds(60);

        TimeSpawn = 3f;

        yield return new WaitForSeconds(60);

        TimeSpawn = 2.5f;
    }

    private IEnumerator MoveStone()
    {
        yield return new WaitForSeconds(TimeSpawn);
        var CurrentObject = StoneList[Random.Range(0, StoneList.Count - 1)];
        CurrentObject.transform.position = new Vector2(RightBorder, Random.Range(DownBorder, UpBorder));
        CurrentObject.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        StartCoroutine(MoveStone());
    }
}
