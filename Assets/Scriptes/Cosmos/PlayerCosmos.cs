using System;
using System.Collections;
using UnityEngine;

public class PlayerCosmos : MonoBehaviour
{
    public bool IsLose { get; private set; }

    [SerializeField] private GameObject _particleSystemWithPiecesOfPlayer;
    [SerializeField] private GameObject _loseMenu;

    [SerializeField] private AudioSource _backgroundSound;

    [SerializeField] private Sprite _stateSpriteWithSingleDamageHits, _stateSpriteWithTwoDamageHits;

    private SpriteRenderer _spriteRenderer;

    private CameraFeatures _cameraFeatures;

    private int _counterStateStatus = 3;

    private void Awake()
    {
        Time.timeScale = 1;

        _spriteRenderer = GetComponent<SpriteRenderer>();

        _backgroundSound.mute = false;
    }

    private void Start() 
    { 
        _cameraFeatures = FindObjectOfType<CameraFeatures>();
        SpawnPlayer();
    }


    private void SpawnPlayer()
    {
        var offSetY = 2.2f;
        var middlePointOfDownBorderOfCamera = _cameraFeatures.LowerLeftPointOfCamera.x + _cameraFeatures.CameraLength / 2;
        transform.position = new Vector2(middlePointOfDownBorderOfCamera, _cameraFeatures.LowerLeftPointOfCamera.y + offSetY);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            _counterStateStatus--;
            if (_counterStateStatus != 0)
                Instantiate(_particleSystemWithPiecesOfPlayer, transform.position, Quaternion.identity);
        }

        if (col.TryGetComponent<Asteroid>(out var asteroidScript))
            StartCoroutine(UpdateStateStatus());
    }

    private void Lose()
    {
        if (IsLose)
        {
            Time.timeScale = 0;
            _loseMenu.SetActive(true);
            _backgroundSound.mute = true;
        }
    }

    private IEnumerator UpdateStateStatus()
    {
        switch (_counterStateStatus)
        {
            case 2:
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.sprite = _stateSpriteWithSingleDamageHits;
                break;
            case 1:
                yield return new WaitForSeconds(0.1f);
                _spriteRenderer.sprite = _stateSpriteWithTwoDamageHits;
                break;
            case 0:
                IsLose = true;
                Lose();
                break;
        }
    }
}
