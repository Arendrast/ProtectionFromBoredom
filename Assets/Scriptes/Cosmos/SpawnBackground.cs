using UnityEngine;

public class SpawnBackground : MonoBehaviour
{
    [SerializeField] private SharedListLibrary LinkOnSharedListLibrary;
    [SerializeField] private GameObject Rectangle;
    private Vector2 ZeroPointsOfCamera, HeightAndWidthOfCamera;
    private const float DefaultHeight = 2;
    private const float DefaultWidth = 2;

    private void Awake()
    {
        SettingRectangle();
        Camera CameraCash = FindObjectOfType<Camera>();
        ZeroPointsOfCamera = CameraCash.ScreenToWorldPoint(new Vector2(0f, 0f));
        HeightAndWidthOfCamera = CameraCash.ScreenToWorldPoint(new Vector2(CameraCash.pixelWidth, CameraCash.pixelHeight));
        SpawnSpawnPoints();
        ZoneExitOfAsteroid();
    }

    private void SettingRectangle()
    {
        var SpriteRendererRectangle = Rectangle.GetComponent<SpriteRenderer>();
        SpriteRendererRectangle.color = new Color(0, 0, 0, 0);
        if (Rectangle.GetComponent<BoxCollider2D>() == null)
        {
            var BC2D = Rectangle.AddComponent<BoxCollider2D>();
            BC2D.isTrigger = true;   
        }
    }
    
    private void SpawnSpawnPoints()
    {
        var LeftPointSpawn = Instantiate(Rectangle);
        var RightPointSpawn = Instantiate(Rectangle);
        var UpPointSpawn = Instantiate(Rectangle);
        var DownPointSpawn = Instantiate(Rectangle);
        var UpperLeftCornerPointSpawn = Instantiate(Rectangle);
        var UpperRightCornerPointSpawn = Instantiate(Rectangle);
        var LowerLeftCornerPointSpawn = Instantiate(Rectangle); 
        var LowerRightCornerPointSpawn = Instantiate(Rectangle);
        LinkOnSharedListLibrary.ListBackground.Add(LeftPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(RightPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(UpPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(DownPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(UpperLeftCornerPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(UpperRightCornerPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(LowerLeftCornerPointSpawn);
        LinkOnSharedListLibrary.ListBackground.Add(LowerRightCornerPointSpawn);

        LeftPointSpawn.transform.localScale = new Vector2(DefaultWidth, HeightAndWidthOfCamera.y);
        LeftPointSpawn.transform.position = new Vector2(-HeightAndWidthOfCamera.x - DefaultWidth/2,0);
        LeftPointSpawn.tag = "LeftPointSpawn";
        
        RightPointSpawn.transform.localScale = new Vector2(DefaultWidth, HeightAndWidthOfCamera.y);
        RightPointSpawn.transform.position = new Vector2(HeightAndWidthOfCamera.x + DefaultWidth/2,0);
        RightPointSpawn.tag = "RightPointSpawn";
        
        UpPointSpawn.transform.localScale = new Vector2(HeightAndWidthOfCamera.x, DefaultHeight);
        UpPointSpawn.transform.position = new Vector2(0, HeightAndWidthOfCamera.y + DefaultHeight/2);
        UpPointSpawn.tag = "UpPointSpawn";
        
        DownPointSpawn.transform.localScale = new Vector2(HeightAndWidthOfCamera.x, DefaultHeight);
        DownPointSpawn.transform.position = new Vector2(0, -HeightAndWidthOfCamera.y - DefaultHeight/2);
        DownPointSpawn.tag = "DownPointSpawn";
        
        UpperLeftCornerPointSpawn.transform.localScale = new Vector2(HeightAndWidthOfCamera.x, HeightAndWidthOfCamera.y);
        UpperLeftCornerPointSpawn.transform.position = new Vector2(ZeroPointsOfCamera.x*1.5f, HeightAndWidthOfCamera.y*1.5f);   
        UpperLeftCornerPointSpawn.tag = "UpperLeftCornerPointSpawn";
        
        UpperRightCornerPointSpawn.transform.localScale = new Vector2(HeightAndWidthOfCamera.x, HeightAndWidthOfCamera.y);      
        UpperRightCornerPointSpawn.transform.position = new Vector2(HeightAndWidthOfCamera.x*1.5f, HeightAndWidthOfCamera.y*1.5f);   
        UpperRightCornerPointSpawn.tag = "UpperRightCornerPointSpawn";
        
        LowerLeftCornerPointSpawn.transform.localScale = new Vector2(HeightAndWidthOfCamera.x, HeightAndWidthOfCamera.y);
        LowerLeftCornerPointSpawn.transform.position = new Vector2(ZeroPointsOfCamera.x * 1.5f, ZeroPointsOfCamera.y * 1.5f);      
        LowerLeftCornerPointSpawn.tag = "LowerLeftCornerPointSpawn";
        
        LowerRightCornerPointSpawn.transform.localScale = new Vector2(HeightAndWidthOfCamera.x, HeightAndWidthOfCamera.y);      
        LowerRightCornerPointSpawn.transform.position = new Vector2(HeightAndWidthOfCamera.x * 1.5f, ZeroPointsOfCamera.y * 1.5f);
        LowerRightCornerPointSpawn.tag = "LowerRightCornerPointSpawn";
    }

    private void ZoneExitOfAsteroid()
    {
        var ZoneExitOfAsteroid = Instantiate(Rectangle);
        ZoneExitOfAsteroid.transform.localScale = new Vector2(HeightAndWidthOfCamera.x * 2, HeightAndWidthOfCamera.y * 2);
        ZoneExitOfAsteroid.transform.position = Vector2.zero;
        ZoneExitOfAsteroid.tag = "ZoneExitOfAsteroid";
    }
}
