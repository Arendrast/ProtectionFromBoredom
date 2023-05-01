using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeManagement : MonoBehaviour
{
    public Vector2 InputVector = Vector2.right;
    [SerializeField] SegmentsSnake SegmentsSnake;
    [SerializeField] private ScoreCounterSnake ScoreCounter;
    public bool IsMove;
    public float TimerOnStart = 1;

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
            {
                InputVector = Vector2.up;
                IsMove = true;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                InputVector = Vector2.down;
                IsMove = true;
            }
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (InputVector.y != 0 && !IsMove)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                InputVector = Vector2.left;
                IsMove = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                InputVector = Vector2.right;
                IsMove = true;
            }
            gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }
    private void Move()
    {
        float x = Mathf.Round(gameObject.transform.position.x) + InputVector.x;
        float y = Mathf.Round(gameObject.transform.position.y) + InputVector.y;
        gameObject.transform.position = new Vector2(x, y);
        IsMove = false;
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.CompareTag("Segment") && Other != SegmentsSnake.Segments[1] && Other != SegmentsSnake.Segments[2] && TimerOnStart < 0)
        {
            SceneManager.LoadScene(3);
        }
        if (Other.gameObject.TryGetComponent<StarOrFood>(out var Star))
        {
            SegmentsSnake.Grow();
            UpdateTimeTeleportation();
            ScoreCounter.Score++;
        }
    }

    private void ResetState()
    {
        gameObject.transform.position = Vector3.zero;
        InputVector = Vector2.right;
    }

    public void Timer()
    {
        if (TimerOnStart > -1)
            TimerOnStart -= Time.deltaTime;
    }
    private void UpdateTimeTeleportation() => Time.fixedDeltaTime -= 0.001f;
}
