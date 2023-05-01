using System.Collections;
using UnityEngine;

public class PlayerCosmos : MonoBehaviour
{
    [SerializeField] private GameObject Particle;
    [SerializeField] private AudioSource BackgroundSound;
    [SerializeField] private Sprite OneDamage, TwoDamage;
    [SerializeField] private GameObject LoseMenu;
    private SpriteRenderer SpriteRendererComponent;
    private int CounterStatus = 3;
    private Vector2 ZeroPointsOfCamera, HeightAndWidthOfCamera;
    public bool IsLose;

    private void Awake()
    {
        Time.timeScale = 1;
        SpriteRendererComponent = GetComponent<SpriteRenderer>();
        GettingCameraDimensions();
        SpawnPlayer();
        BackgroundSound.mute = false;
    }
    private void SpawnPlayer()
    {
        var ScalePlayer = transform.localScale; // Спавн в середине (снизу) экрана
        transform.position = new Vector2(HeightAndWidthOfCamera.x/2, ZeroPointsOfCamera.y + ScalePlayer.y*2.3f);
    }
    private void GettingCameraDimensions()
    {
        var CameraCash = FindObjectOfType<Camera>();
        ZeroPointsOfCamera = CameraCash.ScreenToWorldPoint(new Vector2(0f, 0f));
        HeightAndWidthOfCamera = CameraCash.ScreenToWorldPoint(new Vector2(CameraCash.pixelWidth, CameraCash.pixelHeight));
    }
    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.CompareTag("Enemy"))
        {
            CounterStatus--;
            if (CounterStatus != 0)
                Instantiate(Particle, transform.position, Quaternion.identity);
        }

        if (Col.TryGetComponent<MoveAsteroid>(out var MoveAsteroidScript))
            StartCoroutine(UpdateStatus());
    }

    private void Lose()
    {
        if (IsLose)
        {
            Time.timeScale = 0;
            LoseMenu.SetActive(true);
            BackgroundSound.mute = true;
        }
    }

    private IEnumerator UpdateStatus()
    {
        switch (CounterStatus)
        {
            case 2:
                yield return new WaitForSeconds(0.1f);
                SpriteRendererComponent.sprite = OneDamage;
                break;
            case 1:
                yield return new WaitForSeconds(0.1f);
                SpriteRendererComponent.sprite = TwoDamage;
                break;
            case 0:
                IsLose = true;
                Lose();
                break;
        }
    }
}
