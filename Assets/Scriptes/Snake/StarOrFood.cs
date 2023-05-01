using UnityEngine;

public class StarOrFood : MonoBehaviour
{
    private const float LeftBorderScreen = -16f;
    private const float RightBorderScreen = 16f;
    private const float DownBorderScreen = -9f;
    private const float UpBorderScreen = 9f;
    private bool ProtectfromTwoSpawn;

    private void OnTriggerEnter2D(Collider2D Сol)
    {
        if (Сol.gameObject.TryGetComponent<SnakeManagement>(out var Snake))
        {
            if (!ProtectfromTwoSpawn)
                    TeleportationStar();
        }
        if (Сol.gameObject.CompareTag("Button"))
            TeleportationStar();
    }
    private void TeleportationStar()
    {
        gameObject.transform.position = new Vector2(Random.Range(LeftBorderScreen, RightBorderScreen), Random.Range(DownBorderScreen, UpBorderScreen));
        ProtectfromTwoSpawn = true;
        Invoke(nameof(OffProtect), 1);
    }
    private void OffProtect() => ProtectfromTwoSpawn = false;
}
