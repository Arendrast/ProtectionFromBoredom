using UnityEngine;
using Random = UnityEngine.Random;

public class MoveBackgroundAsteroid : MonoBehaviour
{
    private Rigidbody2D Rb;
    private Vector2 CurrentVector;
    
    private SharedListLibrary LinkOnSharedListLibrary;
    private SpriteRenderer SpriteRendererComponent;
    private bool IsCanTouch = true;

    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        var LinkOnCamera = GameObject.FindObjectOfType<Camera>();
        LinkOnSharedListLibrary = LinkOnCamera.GetComponent<SharedListLibrary>();
        SpriteRendererComponent = GetComponent<SpriteRenderer>();
        var RandomValue = Random.Range(0.05f, 0.1f);
        transform.localScale = new Vector2(RandomValue, RandomValue);
    }

    private void FixedUpdate() => Move();

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (IsCanTouch)
        {
            if (Col.gameObject.CompareTag("LeftPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(0.1f, 1f), Random.Range(-0.9f, 1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("RightPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(-0.9f, -0.1f), Random.Range(-0.9f, 1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("UpPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(-0.9f, 1f), Random.Range(-0.9f, -0.1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("DownPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(-0.9f, 1f), Random.Range(0.1f, 1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("UpperLeftCornerPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(0.1f, 1f), Random.Range(-0.9f, -0.1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("UpperRightCornerPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(-0.9f, -0.1f), Random.Range(-0.9f, -0.1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("LowerLeftCornerPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
                IsCanTouch = false;
            }
            if (Col.gameObject.CompareTag("LowerRightCornerPointSpawn"))
            {
                CurrentVector = new Vector2(Random.Range(-0.9f, -0.1f), Random.Range(0.1f, 1f));
                IsCanTouch = false;
            }   
        }
    }
    private void OnTriggerExit2D(Collider2D Col)
    {
        if (Col.gameObject.CompareTag("ZoneExitOfAsteroid"))
        {
            CurrentVector = Vector2.zero;
            SpriteRendererComponent.sprite = LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid[Random.Range(0, LinkOnSharedListLibrary.ListSpritesTypeOfAsteroid.Count)];
            var RandomValue = Random.Range(0.05f, 0.1f);
            transform.localScale = new Vector2(RandomValue, RandomValue);
            transform.position = LinkOnSharedListLibrary.ListBackground[Random.Range(0, LinkOnSharedListLibrary.ListBackground.Count)].transform.position;
            transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            IsCanTouch = true;
        }
    }
    private void Move()
    {
        if (CurrentVector != Vector2.zero)
            Rb.velocity = CurrentVector;
    }
}
