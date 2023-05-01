using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class ShootingSystemLibrary : MonoBehaviour
{
    [SerializeField] private GameObject Particle;
    [SerializeField] private GameObject Rays;
    public AudioSource SoundShoot;
    public GameObject Bullet;
    public AudioSource SoundRay;
    public GameObject LeftRay;
    public GameObject RightRay;
    private const float SpeedBullet = 15f;
    private const float HeightRays = 12.8f;

    public int CartridgeTypeCounter;

    private bool IsLeftBeamOn;
    private bool IsRightBeamOn;
    public bool IsShootingLeftBlaster;
    public bool IsShootingRightBlaster;
    public bool IsShootingLeftRay;
    public bool IsShootingRightRay;
    public bool IsCanLeftBlasterShoot = true;
    public bool IsCanRightBlasterShoot = true;
    public bool IsCanLeftRayShoot = true;
    public bool IsCanRightRayShoot = true;
    private Vector2 PositionUpperLeftBlaster, PositionMiddleLeftBlaster, PositionLowerLeftBlaster;
    private Vector2 PositionUpperRightBlaster, PositionMiddleRightBlaster, PositionLowerRightBlaster;
    public Vector2 CurrentPositionForLeftBullets, CurrentPositionForRightBullets;

    public ObjectPool<GameObject> PoolBullet;
    private const int LayerMaskAsteroid = 1 << 3;
    public bool OneCheckOnLose;

    private void Start()
    {
        CreatingRays();
        PoolBullet = new ObjectPool<GameObject>(() => Instantiate(Bullet), defaultCapacity: 12, collectionCheck: true,
            maxSize: 24);
        SoundRay.mute = true;
    }


    public void DeterminingPositionsOfLeftBlasters()
    {
        var RandomLeftBlasters = Random.Range(0, 3);
        var Transform = transform;
        switch (RandomLeftBlasters)
        {
            case 2:
                PositionLowerLeftBlaster = new Vector2(Transform.position.x - 2.7245f, transform.position.y - 0.185f);
                CurrentPositionForLeftBullets = PositionLowerLeftBlaster;
                break;
            case 1:
                PositionMiddleLeftBlaster = new Vector2(Transform.position.x - 2.53f, transform.position.y + 0.3f);
                CurrentPositionForLeftBullets = PositionMiddleLeftBlaster;
                break;
            default:
                PositionUpperLeftBlaster = new Vector2(Transform.position.x - 2.7245f, transform.position.y + 0.86f);
                CurrentPositionForLeftBullets = PositionUpperLeftBlaster;
                break;
        }
    }

    public void DeterminingPositionsOfRightBlasters()
    {
        var RandomRightBlasters = Random.Range(0, 3);
        var Transform = transform;
        switch (RandomRightBlasters)
        {
            case 2:
                PositionLowerRightBlaster = new Vector2(Transform.position.x + 2.7245f, transform.position.y - 0.185f);
                CurrentPositionForRightBullets = PositionLowerRightBlaster;
                break;
            case 1:
                PositionMiddleRightBlaster = new Vector2(Transform.position.x + 2.53f, transform.position.y + 0.3f);
                CurrentPositionForRightBullets = PositionMiddleRightBlaster;
                break;
            default:
                PositionUpperRightBlaster = new Vector2(Transform.position.x + 2.7245f, transform.position.y + 0.86f);
                CurrentPositionForRightBullets = PositionUpperRightBlaster;
                break;
        }
    }

    public void CreatingRays()
    {
        LeftRay = Instantiate(Rays);
        LeftRay.SetActive(false);
        RightRay = Instantiate(Rays);
        RightRay.SetActive(false);
    }
    public void ChangingCartridgeType()
    {
        float Scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Scroll > 0)
            CartridgeTypeCounter++;
        if (Scroll < 0)
            CartridgeTypeCounter--;
    }

    public void CreateBulletInShell(Vector2 CurrentPosition)
    {
        var ShellsInGame = PoolBullet.Get();
        ShellsInGame.transform.position = CurrentPosition;
        ShellsInGame.tag = "Laser";
        ShellsInGame.GetComponent<Rigidbody2D>().velocity = Vector2.up * SpeedBullet;
        if (CurrentPosition == CurrentPositionForLeftBullets)
            IsShootingLeftBlaster = true;
        else if (CurrentPosition == CurrentPositionForRightBullets)
            IsShootingRightBlaster = true;
        SoundShoot.Play();
    }

    public void CreateRayInLeftShell()
    {
        var Position = transform.position;
        var HitLeft = Physics2D.Raycast(new Vector2(Position.x - 2.73f, Position.y - 0.4435f), Vector2.up, HeightRays,
            LayerMaskAsteroid);
        var OffsetPosition = new Vector2(2.73f, 0.5565f);
        var OffsetLocalScale = new Vector2(0, 2f);
        if (HitLeft.collider != null)
        {
            LeftRay.transform.localScale = new Vector2(0.15f, HitLeft.distance + OffsetLocalScale.y);
            LeftRay.transform.position = new Vector2(Position.x - OffsetPosition.x,
                Position.y + OffsetPosition.y + HitLeft.distance / 2);
            Instantiate(Particle,
                new Vector2(Position.x - OffsetPosition.x, Position.y + OffsetPosition.y + HitLeft.distance),
                Quaternion.identity);
        }
        else
        {
            LeftRay.transform.localScale = new Vector2(0.15f, HeightRays + OffsetLocalScale.y);
            LeftRay.transform.position = new Vector2(Position.x - OffsetPosition.x,
                Position.y + OffsetPosition.y + HeightRays / 2);
        }

        LeftRay.SetActive(true);
        IsShootingLeftRay = true;
        SoundRay.mute = !IsShootingLeftRay && !IsShootingRightRay;
    }

    public void CreateRayInRightShell()
    {
        var Position = transform.position;
        var HitRight = Physics2D.Raycast(new Vector2(Position.x + 2.7f, Position.y - 0.445f), Vector2.up, HeightRays,
            LayerMaskAsteroid);
        var OffsetPosition = new Vector2(2.7f, 0.555f);
        var OffsetLocalScale = new Vector2(0, 2f);
        if (HitRight.collider != null)
        {
            RightRay.transform.localScale = new Vector2(0.15f, HitRight.distance + OffsetLocalScale.y);
            RightRay.transform.position = new Vector2(Position.x + OffsetPosition.x,
                Position.y + OffsetPosition.y + HitRight.distance / 2);
            Instantiate(Particle, new Vector2(Position.x + OffsetPosition.x, Position.y + HitRight.distance),
                Quaternion.identity);
        }
        else
        {
            RightRay.transform.localScale = new Vector2(0.15f, HeightRays + OffsetLocalScale.y);
            RightRay.transform.position = new Vector2(Position.x + OffsetPosition.x,
                Position.y + OffsetPosition.y + HeightRays / 2);
        }

        RightRay.SetActive(true);
        IsShootingRightRay = true;
    }
}
