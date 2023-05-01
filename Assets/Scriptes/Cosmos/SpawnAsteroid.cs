using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnAsteroid : MonoBehaviour
{
    private SharedListLibrary LinkOnSharedListLibrary;
    [SerializeField] private List<GameObject> ListAsteroid;
    private const float UpBorder = 14;
    private const float LeftBorder = -12;
    private const float RightBorder = 12;
    private float TimeSpawn = 5f;

    private void Awake()
    {
        var LinkOnCamera = GameObject.Find("Main Camera");
        LinkOnSharedListLibrary = LinkOnCamera.GetComponent<SharedListLibrary>();
        StartCoroutine(UpdateTimeSpawn());
        StartCoroutine(UpdatePosition());
    }

    private void Start() => Spawn();

    private IEnumerator UpdateTimeSpawn()
    {
        yield return new WaitForSeconds(60);
        TimeSpawn = 4f;
        yield return new WaitForSeconds(60);
        TimeSpawn = 3.5f;
        yield return new WaitForSeconds(60);
        TimeSpawn = 3f;
    }

    private void Spawn()
    {
        for (var I = 0; I < 4; I++)
        {
            var CurrentAsteroid =
                Instantiate(LinkOnSharedListLibrary.Asteroid, new Vector2(100, 100), Quaternion.identity);
            var SpriteRendererOfCurrentAsteroid = CurrentAsteroid.GetComponent<SpriteRenderer>();
            var RandomValue = Random.Range(0, LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid.Count);
            SpriteRendererOfCurrentAsteroid.sprite = LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid[RandomValue];
            var ScriptOfCurrentAsteroid = CurrentAsteroid.GetComponent<MoveAsteroid>();
            ScriptOfCurrentAsteroid.OffAllCollidersOnAsteroid();
            ScriptOfCurrentAsteroid.ListColliderOfAsteroid[RandomValue].enabled = true;
            ScriptOfCurrentAsteroid.ListColliderOfAsteroid[RandomValue].isTrigger = true;
            CurrentAsteroid.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            CurrentAsteroid.transform.localScale = new Vector2(Random.Range(0.75f, 1.51f), Random.Range(0.75f, 1.51f));
            CurrentAsteroid.tag = "Enemy";
            ListAsteroid.Add(CurrentAsteroid);
        }
    }

    private IEnumerator UpdatePosition()
    {
        for (var I = 0; I < 4; I++)
        {
            yield return new WaitForSeconds(TimeSpawn);
            var CurrentAsteroid = ListAsteroid[I];
            var SpriteRendererOfCurrentAsteroid = CurrentAsteroid.GetComponent<SpriteRenderer>();
            var RandomValue = Random.Range(0, LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid.Count);
            SpriteRendererOfCurrentAsteroid.sprite = LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid[RandomValue];
            var ScriptOfCurrentAsteroid = CurrentAsteroid.GetComponent<MoveAsteroid>();
            ScriptOfCurrentAsteroid.OffAllCollidersOnAsteroid();
            ScriptOfCurrentAsteroid.ListColliderOfAsteroid[RandomValue].enabled = true;
            ScriptOfCurrentAsteroid.ListColliderOfAsteroid[RandomValue].isTrigger = true;
            CurrentAsteroid.transform.localScale = new Vector2(Random.Range(0.75f, 1.51f), Random.Range(0.75f, 1.51f));
            CurrentAsteroid.transform.position = new Vector2(Random.Range(LeftBorder, RightBorder), UpBorder);
        }
        StartCoroutine(UpdatePosition());
    }
}

