using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;

public class SnakeManagement : MonoBehaviour
{
    public Vector2 InputVector { get; private set; } = Vector2.right;

    public bool IsMove { get; private set; }

    [SerializeField] private SegmentsSnake _segmentsSnake;
    [SerializeField] private ScoreCounterSnake _scoreCounter;

    [SerializeField] private float speedUpdateUnit = 0.001f;

    private float _timerOnStart = 1;

    private void Awake()
    {
        ResetState();
        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.2f;
        InvokeRepeating(nameof(UpdateTimeTeleportation), 0, 1);
    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            ManagementVector();
            Timer();
        }
    }

    private void FixedUpdate()
    {
        if (Time.timeScale == 1)
            Move();
    }

    private void ManagementVector()
    {
        if (InputVector.x != 0 && !IsMove)
        {
            if (Input.GetKeyDown(KeyCode.W))
                SetVectorMovement(Vector2.up);
            
            else if (Input.GetKeyDown(KeyCode.S))
                SetVectorMovement(Vector2.down);

            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (InputVector.y != 0 && !IsMove)
        {
            if (Input.GetKeyDown(KeyCode.A))
                SetVectorMovement(Vector2.left);

            if (Input.GetKeyDown(KeyCode.D))
                SetVectorMovement(Vector2.right);

            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    private void Move()
    {
        var positionX = Mathf.Round(gameObject.transform.position.x) + InputVector.x;
        var positionY = Mathf.Round(gameObject.transform.position.y) + InputVector.y;
        gameObject.transform.position = new Vector2(positionX, positionY);
        IsMove = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Segment") && other != _segmentsSnake.SegmentList[1] && other != _segmentsSnake.SegmentList[2] && _timerOnStart < 0)
            SceneManager.LoadScene(3);
        if (other.gameObject.TryGetComponent<StarOrFood>(out var Star))
        {
            _segmentsSnake.Grow();
            UpdateTimeTeleportation();
            _scoreCounter.AddPoint();
        }
    }

    private void ResetState()
    {
        gameObject.transform.position = Vector2.zero;
        InputVector = Vector2.right;
    }

    public void Timer()
    {
        if (_timerOnStart > -1)
            _timerOnStart -= Time.deltaTime;
    }
    private void UpdateTimeTeleportation() => Time.fixedDeltaTime -= speedUpdateUnit;
    
    public void SetVectorMovement(Vector2 vector)
    {
        InputVector = vector;
        IsMove = true;
    }
}
