using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    [SerializeField] private Collider2D _colliderOfFirstTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfSecondTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfThirdTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfFourthTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfFifthTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfSixthTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfSeventhTypeOfAsteroid;
    [SerializeField] private Collider2D _colliderOfEighthTypeOfAsteroid;
    
    public List<Collider2D> ListColliderOfAsteroid { get; private set; } = new List<Collider2D>();

    private void AddElementsInList()
    {
        ListColliderOfAsteroid.Add(_colliderOfFirstTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfSecondTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfThirdTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfFourthTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfFifthTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfSixthTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfSeventhTypeOfAsteroid);
        ListColliderOfAsteroid.Add(_colliderOfEighthTypeOfAsteroid);
    }

    private Rigidbody2D _rb;
    
    private bool _isDiscarded;
    
    private int _destructionCounter;
    
    private StorageOfStagesOfDestruction _storageOfStagesOfDestruction;

    private GameObject _currentObjectOfDestruction;
    private SpriteRenderer _spriteRendererOfObjectOfDestruction;

    private Vector2 positionOutScreen = new Vector2(100, 100);
    
    private float _timeOfDestruction = 0.3f;
    private float _beginTimeOfDestruction = 0.3f;
    private float _speedOfAsteroid = 5f;

    private void Awake() => AddElementsInList();
    

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _storageOfStagesOfDestruction = FindObjectOfType<StorageOfStagesOfDestruction>();
        SpawnObjectOfDestruction();
    }

    public void OffAllColliderOnAsteroid()
    {
        for (var I = ListColliderOfAsteroid.Count - 1; I > -1; I--)
            ListColliderOfAsteroid[I].enabled = false;
    }

    private void SpawnObjectOfDestruction()
    {
        _currentObjectOfDestruction = Instantiate(_storageOfStagesOfDestruction.ObjectOfDestruction, transform.position, Quaternion.identity, transform);
        _spriteRendererOfObjectOfDestruction = _currentObjectOfDestruction.GetComponent<SpriteRenderer>();
    } 
    
    private void DiscardingOnCollision()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        _isDiscarded = true;
        Invoke(nameof(OffStatusDiscarded), 0.5f);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent<PlayerCosmos>(out var playerScript))
            Invoke(nameof(DiscardingOnCollision), 0.1f);
        
        if (col.gameObject.CompareTag("Laser"))
        {
            _destructionCounter++;
            ChangeStateDestruction();
        }
        
        if (col.gameObject.CompareTag("DownBorder"))
            ResetToZeroParametersOfDestructionObject();
    }

    private void DestructionOnRayHits()
    {
        if (_timeOfDestruction > 0)
            _timeOfDestruction -= Time.deltaTime;
        else
        {
            _destructionCounter++;
            _timeOfDestruction = _beginTimeOfDestruction;
            ChangeStateDestruction();
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ray"))
            DestructionOnRayHits();
    }
    
    private void OffStatusDiscarded() => _isDiscarded = false;

    private void FixedUpdate() => Move();

    private void Move()
    {
        if (!_isDiscarded)
            _rb.velocity = Vector2.down * _speedOfAsteroid;
    }

    private void ChangeStateDestruction()
    {
        switch (_destructionCounter)
        {
            case 1:
                ChangeSpriteOfObjectOfDestruction(_storageOfStagesOfDestruction.FirstStageOfDestruction);
                break;
            case 2:
                ChangeSpriteOfObjectOfDestruction(_storageOfStagesOfDestruction.SecondStageOfDestruction);
                break;
            case 3:
                ChangeSpriteOfObjectOfDestruction(_storageOfStagesOfDestruction.ThirdStageOfDestruction);
                break;
            case 4:
                ChangeSpriteOfObjectOfDestruction(_storageOfStagesOfDestruction.FourthStageOfDestruction);
                break;
            case 5:
                ChangeSpriteOfObjectOfDestruction(_storageOfStagesOfDestruction.FifthStageOfDestruction);
                break;
            case 6:
                transform.position = positionOutScreen;
                ResetToZeroParametersOfDestructionObject();
                break;
        }
    }
    
    private void ChangeSpriteOfObjectOfDestruction(Sprite sprite) => _spriteRendererOfObjectOfDestruction.sprite = sprite;
    private void ResetToZeroParametersOfDestructionObject()
    {
        _destructionCounter = 0;
        _spriteRendererOfObjectOfDestruction.sprite = null; 
    }
}

