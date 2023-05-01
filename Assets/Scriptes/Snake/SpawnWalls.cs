using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [SerializeField] private GameObject UpBorder, DownBorder, LeftBorder, RightBorder, AntiBugRectangle;
    private const float WidthLeftBorder = 15f, WidthRightBorder = 15f, HeightUpBorder = 15f, HeightDownBorder = 15f;
    private void Awake() => Spawn();
    
    private void Spawn()
    {
        Camera CameraCash = FindObjectOfType<Camera>();
        Vector2 DownLeftPointCamera = CameraCash.ScreenToWorldPoint(new Vector2(0f, 0f));
        Vector2 UpRightPointCamera = CameraCash.ScreenToWorldPoint(new Vector2(CameraCash.pixelWidth, CameraCash.pixelHeight));
        Vector2 DownRightPointCamera = CameraCash.ScreenToWorldPoint(new Vector2(CameraCash.pixelWidth, 0f));
        GameObject UpBorderInGame = Instantiate(UpBorder, new Vector2(0, UpRightPointCamera.y + HeightUpBorder / 2), Quaternion.identity);
        GameObject DownBorderInGame = Instantiate(DownBorder, new Vector2(0, DownRightPointCamera.y - HeightDownBorder / 2), Quaternion.identity);
        GameObject RightBorderInGame = Instantiate(RightBorder, new Vector2(UpRightPointCamera.x + WidthRightBorder / 2, 0), Quaternion.identity);
        GameObject LeftBorderInGame = Instantiate(LeftBorder, new Vector2(DownLeftPointCamera.x - WidthLeftBorder / 2, 0), Quaternion.identity);
        UpBorderInGame.gameObject.transform.localScale = new Vector2(UpRightPointCamera.x * 2, HeightUpBorder);
        DownBorderInGame.gameObject.transform.localScale = new Vector2(DownRightPointCamera.x * 2, HeightDownBorder);
        RightBorderInGame.gameObject.transform.localScale = new Vector2(WidthRightBorder, UpRightPointCamera.y * 2);
        LeftBorderInGame.gameObject.transform.localScale = new Vector2(WidthLeftBorder, UpRightPointCamera.y * 2);
        AntiBugRectangle.gameObject.transform.position = Vector2.zero;
        AntiBugRectangle.gameObject.transform.localScale = new Vector2(UpRightPointCamera.x * 2, DownLeftPointCamera.y * 2);
    }
}
