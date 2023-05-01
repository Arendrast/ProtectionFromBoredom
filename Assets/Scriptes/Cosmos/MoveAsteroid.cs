using System;
using System.Collections.Generic;
using UnityEngine;


public class MoveAsteroid : MonoBehaviour
{
    private Rigidbody2D Rb;
    private bool IsDiscarded;
    private int DestructionCounter;
    private SharedListLibrary SharedListLibraryScript;
    [SerializeField] private Collider2D FirstTypeOfAsteroidCollider;
    [SerializeField] private Collider2D SecondTypeOfAsteroidCollider;
    [SerializeField] private Collider2D ThirdTypeOfAsteroidCollider;
    [SerializeField] private Collider2D FourthTypeOfAsteroidCollider;
    [SerializeField] private Collider2D FifthTypeOfAsteroidCollider;
    [SerializeField] private Collider2D SixthTypeOfAsteroidCollider;
    [SerializeField] private Collider2D SeventhTypeOfAsteroidCollider;
    [SerializeField] private Collider2D EighthTypeOfAsteroidCollider;
    public List<Collider2D> ListColliderOfAsteroid;
    private GameObject CurrentObjectDestruction;
    private float TimeDestructionOnRayHits = 0.3f;

    private void Awake() => AddingInListColliderOfAsteroid();
    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        var CameraCash = FindObjectOfType<Camera>();
        SharedListLibraryScript = CameraCash.GetComponent<SharedListLibrary>();
        SpawnObjectDestruction();
    }

    private void AddingInListColliderOfAsteroid()
    {
        ListColliderOfAsteroid.Add(FirstTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(SecondTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(ThirdTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(FourthTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(FifthTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(SixthTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(SeventhTypeOfAsteroidCollider);
        ListColliderOfAsteroid.Add(EighthTypeOfAsteroidCollider);
    }
    
    public void OffAllCollidersOnAsteroid()
    {
        for (var I = ListColliderOfAsteroid.Count - 1; I > -1; I--)
            ListColliderOfAsteroid[I].enabled = false;
    }

    private void SpawnObjectDestruction() => CurrentObjectDestruction = Instantiate(SharedListLibraryScript.ObjectDestruction, transform.position, Quaternion.identity, transform);
    
    private void DiscardingOnCollision()
    {
        Rb.velocity = Vector2.zero;
        Rb.AddForce(Vector2.up * 5, ForceMode2D.Impulse); // Это отбрасывание
        IsDiscarded = true;
        Invoke(nameof(OffStatusDiscarded), 0.5f);
    }
    
    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.TryGetComponent<PlayerCosmos>(out var PlayerScript))
            Invoke(nameof(DiscardingOnCollision), 0.1f);
        
        if (Col.gameObject.CompareTag("Laser"))
        {
            DestructionCounter++;
            ChangeDestruction();
        }
        

        if (Col.gameObject.CompareTag("DownBorder"))
            ChangeOfDestructionWhenExitingScreen();
    }

    private void DestructionOnRayHits()
    {
        if (TimeDestructionOnRayHits > 0)
            TimeDestructionOnRayHits -= Time.deltaTime;
        else
        {
            DestructionCounter++;
            TimeDestructionOnRayHits = 0.3f;
            ChangeDestruction();
        }
    }
    private void OnTriggerStay2D(Collider2D Col)
    {
        if (Col.gameObject.CompareTag("Ray"))
            DestructionOnRayHits();
    }
    
    private void OffStatusDiscarded() => IsDiscarded = false;

    private void FixedUpdate() => Move();

    private void Move()
    {
        if (!IsDiscarded)
            Rb.velocity = Vector2.down * 5f;
    }

    private void ChangeDestruction()
    {
        var SpriteRendererOfObjectDestruction = CurrentObjectDestruction.GetComponent<SpriteRenderer>();
        switch (DestructionCounter)
        {
            case 1:
                SpriteRendererOfObjectDestruction.sprite = SharedListLibraryScript.FirstStageOfDestruction;
                break;
            case 2:
                SpriteRendererOfObjectDestruction.sprite = SharedListLibraryScript.SecondStageOfDestruction;
                break;
            case 3:
                SpriteRendererOfObjectDestruction.sprite = SharedListLibraryScript.ThirdStageOfDestruction;
                break;
            case 4:
                SpriteRendererOfObjectDestruction.sprite = SharedListLibraryScript.FourthStageOfDestruction;
                break;
            case 5:
                SpriteRendererOfObjectDestruction.sprite = SharedListLibraryScript.FifthStageOfDestruction;
                break;
            case 6:
                transform.position = new Vector2(100, 100);
                DestructionCounter = 0;
                SpriteRendererOfObjectDestruction.sprite = null;
                break;
        }
    }

    private void ChangeOfDestructionWhenExitingScreen()
    {
        var SpriteRendererOfObjectDestruction = CurrentObjectDestruction.GetComponent<SpriteRenderer>();
        DestructionCounter = 0;
        SpriteRendererOfObjectDestruction.sprite = null; 
    }
}

