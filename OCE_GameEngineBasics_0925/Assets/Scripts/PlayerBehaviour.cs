using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehaviour : MonoBehaviour
{
    public float _speed = 5;
    public float _jumpHeight = 4;

    Vector2 _playerPosition;

    // new input system
    private GameInput _gameInput;
    private InputAction _move;
    private InputAction _jump;

    Rigidbody2D rb;

    private void Awake()
    {
        _gameInput = new GameInput();

        _move = _gameInput.Player.Move;
        _jump = _gameInput.Player.Jump;

        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _gameInput.Player.Enable();
    }

    private void OnDisable()
    {
        _gameInput.Player.Disable();
    }

    void Start()
    {
        _playerPosition = GetComponent<Transform>().position;
    }

    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 velocity;

        velocity.x = _move.ReadValue<float>() * _speed;
        velocity.y = rb.linearVelocity.y;

        if (_jump.WasPressedThisFrame())
        {
            velocity.y = _jumpHeight;
        }

        rb.linearVelocity = velocity;
    }
}
