using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private AudioSource BackgroundSound;
    [SerializeField] private GameObject LoseUI;
    public float Velocity = 4;
    private bool IsPressSpace, IsPressS;
    public bool IsLose;
    private Rigidbody2D Rb;
    private void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Rb.freezeRotation = true;
        InvokeRepeating(nameof(UpdateVelocity), 0, 1);
        Time.timeScale = 1;
        BackgroundSound.mute = false;
    }
    private void FixedUpdate() => Jump();
    
    private void Update() => PressButton();

    private void Jump()
    {
        if (IsPressSpace)
            Rb.velocity = Vector2.up * Velocity * 1.5f;

        if (IsPressS) 
            Rb.velocity = Vector2.down * Velocity * 1.5f;
    }
    private void PressButton()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) IsPressSpace = true;
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            IsPressSpace = false;
            Rb.velocity = Vector2.zero;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) IsPressS = true;
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            IsPressS = false;
            Rb.velocity = Vector2.zero;
        }
    }

    private void UpdateVelocity() => Velocity += 0.03333333334f;

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.TryGetComponent(out Obstacle Obstacle))
        {
            Time.timeScale = 0;
            LoseUI.SetActive(true);
            IsLose = true;
            BackgroundSound.mute = true;
        }
    }
}
