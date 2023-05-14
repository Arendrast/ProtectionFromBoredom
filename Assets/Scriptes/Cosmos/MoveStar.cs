using UnityEngine;
using Random = UnityEngine.Random;

public class MoveStar : MonoBehaviour
{
    [SerializeField] private GameObject _neighboringStars;
    
    [SerializeField] private float _speedMove;
    [SerializeField] private float _downBorder = -12.96f;
    [SerializeField] private float _heightObject = 12.96f;

    private float _fixedDeltaTime = 0.02f; 

    private StorageOfLocationOfStars _storageOfLocationOfStars;
    
    private SpriteRenderer _spriteRenderer;
    
    private Rigidbody2D _rb;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        
        _rb.gravityScale = 0;
        
        Time.fixedDeltaTime = _fixedDeltaTime;

        InvokeRepeating(nameof(Velocity), 0, 1);
    }

    private void Start()
    {
        _storageOfLocationOfStars = FindObjectOfType<StorageOfLocationOfStars>();
        _spriteRenderer.sprite = _storageOfLocationOfStars.ListOfStarLocations[Random.Range(0, _storageOfLocationOfStars.ListOfStarLocations.Count)];  
    } 
    

    private void FixedUpdate()
    {
        UpdatePosition();
        Move();
    }

    private void Move() => _rb.velocity = Vector2.down * _speedMove;

    private void Velocity() => _speedMove += 0.03333333334f;
    
    private void UpdatePosition()
    {
        if (gameObject.transform.position.y <= _downBorder)
        {
            var positionNeighboring = _neighboringStars.transform.position;
            transform.position = new Vector2(positionNeighboring.x, positionNeighboring.y + _heightObject);
            var randomRotation = Random.Range(0, 2);
            transform.rotation = Quaternion.Euler(0, 0, randomRotation == 0 ? 0 : 180);
            _spriteRenderer.sprite = _storageOfLocationOfStars.ListOfStarLocations[Random.Range(0, _storageOfLocationOfStars.ListOfStarLocations.Count)];
        } 
    }
}
