using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnBackgroundAsteroid : MonoBehaviour
{
    [SerializeField] private SharedListLibrary LinkOnSharedListLibrary;

    private void Start() => SpawnAsteroid();
    private void SpawnAsteroid()
    {
        for (var I = 0; I < 8; I++)
        { 
            var CurrentAsteroid = Instantiate(LinkOnSharedListLibrary.BackgroundAsteroid);
           var CurrentSpriteRenderer = CurrentAsteroid.GetComponent<SpriteRenderer>();
           CurrentSpriteRenderer.sprite = LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid[Random.Range(0, LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid.Count)];
           CurrentSpriteRenderer.transform.position = LinkOnSharedListLibrary.ListBackground[I].transform.position;
           CurrentAsteroid.transform.localScale = new Vector2(0.1f, 0.1f);
        }
    }
}
