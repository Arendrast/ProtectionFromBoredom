using UnityEngine;

public class PlayerRunner : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundSound;
    [SerializeField] private GameObject _loseUI;
    public float Velocity { get; private set; } = 4;
    private bool _isPressSpace, _isPressS;
    public bool _isLose { get; private set; }
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.freezeRotation = true;
        InvokeRepeating(nameof(UpdateVelocity), 0, 1);
        Time.timeScale = 1;
        _backgroundSound.mute = false;
    }
    private void FixedUpdate() => Move();
    
    private void Update() => PressButton();

    private void Move()
    {
        if (_isPressSpace)
            SetVectorMove(Vector2.up);

        if (_isPressS) 
            SetVectorMove(Vector2.down);
    }

    private void SetVectorMove(Vector2 vectorMove) => _rb.velocity = vectorMove * Velocity;
    
    private void PressButton()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) _isPressSpace = true;
        
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.UpArrow))
            DoStatePressedButtonFalse(ref _isPressSpace);
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) _isPressS = true;
        
        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
            DoStatePressedButtonFalse(ref _isPressS);
    }

    private void DoStatePressedButtonFalse(ref bool button)
    {
        button = false;
        _rb.velocity = Vector2.zero;
    }

    private void UpdateVelocity() => Velocity += 0.03333333334f;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Obstacle Obstacle))
            Lose();
    }

    private void Lose()
    {
        Time.timeScale = 0;
        _loseUI.SetActive(true);
        _isLose = true;
        _backgroundSound.mute = true;
    }
}
