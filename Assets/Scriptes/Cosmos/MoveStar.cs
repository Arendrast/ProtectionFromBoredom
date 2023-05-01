using UnityEngine;
using Random = UnityEngine.Random;


public class MoveStar : MonoBehaviour
{
    [SerializeField] private GameObject NeighboringStars;
    [SerializeField] private float SpeedMove;
    [SerializeField] private float DownBorder = -12.96f;
    [SerializeField] private float HeightObject = 12.96f;
    private SharedListLibrary SharedListLibraryLink;
    private SpriteRenderer SpriteRendererComponent;
    private Rigidbody2D Rb;
    private void Awake()
    {
        var CameraCash = FindObjectOfType<Camera>();
        SharedListLibraryLink = CameraCash.GetComponent<SharedListLibrary>();
        Rb = GetComponent<Rigidbody2D>();
        SpriteRendererComponent = GetComponent<SpriteRenderer>();
        Time.fixedDeltaTime = 0.02f;
        Rb.gravityScale = 0;
        InvokeRepeating(nameof(Velocity), 0, 1);
    }

    private void Start() => SpriteRendererComponent.sprite = SharedListLibraryLink.ListOfStarLocations[Random.Range(0, SharedListLibraryLink.ListOfStarLocations.Count)];
    

    private void FixedUpdate()
    {
        Teleport();
        Move();
    }

    private void Move() => Rb.velocity = Vector2.down * SpeedMove;

    private void Velocity() => SpeedMove += 0.03333333334f;
    
    private void Teleport()
    {
        if (gameObject.transform.position.y <= DownBorder)
        {
            var PositionNeighboring = NeighboringStars.transform.position;
            transform.position = new Vector2(PositionNeighboring.x, PositionNeighboring.y + HeightObject);
            var RandomRotation = Random.Range(0, 2);
            transform.rotation = Quaternion.Euler(0, 0, RandomRotation == 0 ? 0 : 180);
            SpriteRendererComponent.sprite = SharedListLibraryLink.ListOfStarLocations[Random.Range(0, SharedListLibraryLink.ListOfStarLocations.Count)];
        } 
    }
}
