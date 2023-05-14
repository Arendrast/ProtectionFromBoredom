using UnityEngine;

public class StarOrFood : MonoBehaviour
{
    private const float _leftBorderScreen = -16f;
    private const float _rightBorderScreen = 16f;
    private const float _downBorderScreen = -9f;
    private const float _upBorderScreen = 9f;
    private bool _protectFromTwoSpawn;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent<SnakeManagement>(out var Snake))
        {
            if (!_protectFromTwoSpawn)
                    TeleportationStar();
        }
        if (col.gameObject.CompareTag("Button"))
            TeleportationStar();
    }
    private void TeleportationStar()
    {
        gameObject.transform.position = new Vector2(Random.Range(_leftBorderScreen, _rightBorderScreen), Random.Range(_downBorderScreen, _upBorderScreen));
        _protectFromTwoSpawn = true;
        Invoke(nameof(OffProtect), 1);
    }
    private void OffProtect() => _protectFromTwoSpawn = false;
}
