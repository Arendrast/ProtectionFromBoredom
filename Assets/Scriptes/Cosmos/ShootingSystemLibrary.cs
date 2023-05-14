using System;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class ShootingSystemLibrary : MonoBehaviour
{
    public bool IsShootingLeftBlaster { get; private set; }
    public bool IsShootingRightBlaster { get; private set; }
    public bool IsShootingLeftRay { get; private set; }
    public bool IsShootingRightRay { get; private set; }
    public bool IsCanLeftBlasterShoot { get; private set; } = true;
    public bool IsCanRightBlasterShoot { get; private set; } = true;
    public bool IsCanLeftRayShoot { get; private set; } = true;
    public bool IsCanRightRayShoot { get; private set; } = true;
    public int CartridgeTypeCounter { get; private set; }
    public Vector2 CurrentPositionSpawnOfLeftBullets { get; private set; }
    public Vector2 CurrentPositionSpawnOfRightBullets { get; private set; }
    
    public GameObject LeftRay { get; private set; }
    public GameObject RightRay { get; private set; }
    
    public AudioSource SoundShoot;
    public AudioSource SoundRay;

    [SerializeField] private GameObject _particleSystem;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _ray;

    private const float _speedBlaster = 15f;
    private const float _lengthRay = 12.8f;

    private bool _isLeftRayOn;
    private bool _isRightRayOn;

    private Vector2 _positionOfUpperLeftBlaster, _positionOfMiddleLeftBlaster, _positionOfLowerLeftBlaster;
    private Vector2 _positionOfUpperRightBlaster, _positionOfMiddleRightBlaster, _positionOfLowerRightBlaster;

    public ObjectPool<GameObject> PoolBullet;

    private const int _layerMaskAsteroid = 1 << 3;

    private void Start()
    {
        CreateRays();
        CreatePool();
        SoundRay.mute = true;
    }

    public void DisableUnnecessaryWhenLosing()
    {
        RightRay.SetActive(false);
        LeftRay.SetActive(false);
        IsShootingLeftRay = false;
        IsShootingRightRay = false;
        SoundRay.mute = true;
    }

    public void AddValueInCartridgeTypeCounter() => CartridgeTypeCounter++;
    public void SetIsCanShootingLeftBlaster(bool value) => IsCanLeftBlasterShoot = value;
    public void SetIsCanShootingRightBlaster(bool value) => IsCanRightBlasterShoot = value;
    public void SetIsCanShootingLeftRay(bool value) => IsCanLeftRayShoot = value;
    public void SetIsCanShootingRightRay(bool value) => IsCanRightRayShoot = value;
    public void SetIsShootingLeftBlaster(bool value) => IsShootingLeftBlaster = value;
    public void SetIsShootingRightBlaster(bool value) => IsShootingRightBlaster = value;
    public void SetIsShootingLeftRay(bool value) => IsShootingLeftRay = value;
    public void SetIsShootingRightRay(bool value) => IsShootingRightRay = value;

    private void CreatePool() =>PoolBullet = new ObjectPool<GameObject>(() => Instantiate(_bullet), defaultCapacity: 12, collectionCheck: true,
            maxSize: 24);

    public void DeterminePositionOfLeftBlasters()
    {
        var RandomLeftBlasters = Random.Range(0, 3);
        var Transform = transform;
        switch (RandomLeftBlasters)
        {
            case 2:
                _positionOfLowerLeftBlaster = new Vector2(Transform.position.x - 2.7245f, transform.position.y - 0.185f);
                CurrentPositionSpawnOfLeftBullets = _positionOfLowerLeftBlaster;
                break;
            case 1:
                _positionOfMiddleLeftBlaster = new Vector2(Transform.position.x - 2.53f, transform.position.y + 0.3f);
                CurrentPositionSpawnOfLeftBullets = _positionOfMiddleLeftBlaster;
                break;
            default:
                _positionOfUpperLeftBlaster = new Vector2(Transform.position.x - 2.7245f, transform.position.y + 0.86f);
                CurrentPositionSpawnOfLeftBullets = _positionOfUpperLeftBlaster;
                break;
        }
    }
    
    public void DeterminePositionOfRightBlasters()
    {
        var RandomRightBlasters = Random.Range(0, 3);
        var Transform = transform;
        switch (RandomRightBlasters)
        {
            case 2:
                _positionOfLowerRightBlaster = new Vector2(Transform.position.x + 2.7245f, transform.position.y - 0.185f);
                CurrentPositionSpawnOfRightBullets = _positionOfLowerRightBlaster;
                break;
            case 1:
                _positionOfMiddleRightBlaster = new Vector2(Transform.position.x + 2.53f, transform.position.y + 0.3f);
                CurrentPositionSpawnOfRightBullets = _positionOfMiddleRightBlaster;
                break;
            default:
                _positionOfUpperRightBlaster = new Vector2(Transform.position.x + 2.7245f, transform.position.y + 0.86f);
                CurrentPositionSpawnOfRightBullets = _positionOfUpperRightBlaster;
                break;
        }
    }

    public void CreateRays()
    {
        LeftRay = Instantiate(_ray);
        LeftRay.SetActive(false);
        RightRay = Instantiate(_ray);
        RightRay.SetActive(false);
    }
    public void ChangeCartridgeType()
    {
        var Scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Scroll > 0)
            CartridgeTypeCounter++;
        if (Scroll < 0)
            CartridgeTypeCounter--;
    }

    public void CreateBulletInBlaster(Vector2 currentPosition)
    {
        var ShellsInGame = PoolBullet.Get();
        ShellsInGame.transform.position = currentPosition;
        ShellsInGame.tag = "Laser";
        ShellsInGame.GetComponent<Rigidbody2D>().velocity = Vector2.up * _speedBlaster;
        if (currentPosition == CurrentPositionSpawnOfLeftBullets)
            IsShootingLeftBlaster = true;
        else if (currentPosition == CurrentPositionSpawnOfRightBullets)
            IsShootingRightBlaster = true;
        SoundShoot.Play();
    }

    public void CreateRayInLeftBlaster()
    {
        var position = transform.position;
        var hitLeft = Physics2D.Raycast(new Vector2(position.x - 2.73f, position.y - 0.4435f), Vector2.up, _lengthRay,
            _layerMaskAsteroid);
        var offSetPosition = new Vector2(2.73f, 0.5565f);
        var OffSetLocalScale = new Vector2(0, 2f);
        if (hitLeft.collider != null)
        {
            LeftRay.transform.localScale = new Vector2(0.15f, hitLeft.distance + OffSetLocalScale.y);
            LeftRay.transform.position = new Vector2(position.x - offSetPosition.x,
                position.y + offSetPosition.y + hitLeft.distance / 2);
            Instantiate(_particleSystem, new Vector2(position.x - offSetPosition.x, position.y + offSetPosition.y + hitLeft.distance),
                Quaternion.identity);
        }
        else
        {
            LeftRay.transform.localScale = new Vector2(0.15f, _lengthRay + OffSetLocalScale.y);
            LeftRay.transform.position = new Vector2(position.x - offSetPosition.x, position.y + offSetPosition.y + _lengthRay / 2);
        }

        LeftRay.SetActive(true);
        IsShootingLeftRay = true;
        SoundRay.mute = !IsShootingLeftRay && !IsShootingRightRay;
    }

    public void CreateRayInRightShell()
    {
        var position = transform.position;
        var hitRight = Physics2D.Raycast(new Vector2(position.x + 2.7f, position.y - 0.445f), Vector2.up, _lengthRay,
            _layerMaskAsteroid);
        var offSetPosition = new Vector2(2.7f, 0.555f);
        var offSetLocalScale = new Vector2(0, 2f);
        if (hitRight.collider != null)
        {
            RightRay.transform.localScale = new Vector2(0.15f, hitRight.distance + offSetLocalScale.y);
            RightRay.transform.position = new Vector2(position.x + offSetPosition.x,
                position.y + offSetPosition.y + hitRight.distance / 2);
            Instantiate(_particleSystem, new Vector2(position.x + offSetPosition.x, position.y + hitRight.distance),
                Quaternion.identity);
        }
        else
        {
            RightRay.transform.localScale = new Vector2(0.15f, _lengthRay + offSetLocalScale.y);
            RightRay.transform.position = new Vector2(position.x + offSetPosition.x,
                position.y + offSetPosition.y + _lengthRay / 2);
        }

        RightRay.SetActive(true);
        IsShootingRightRay = true;
        SoundRay.mute = !IsShootingLeftRay && !IsShootingRightRay;
    }

}
    
