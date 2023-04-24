using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _myRigidBody;

    [Header("Movement Setup")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpHeigth = 5f;
    [SerializeField] private Vector2 _counterJumpForce = new Vector2();

    private Vector2 _movement;
    private float _horizontalInput;
    private float _verticalInput;

    private bool _isGrounded = true;
    private bool _isJumping;
    private bool _jumpKeyHeld;

    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _movement = new Vector2(_horizontalInput, _verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _jumpKeyHeld = true;

            if (_isGrounded)
            {
                _isJumping = true;

            }
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _jumpKeyHeld = false;

        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        _jumpForce = CalculateJumpForce(Physics2D.gravity.magnitude, _jumpHeigth);

        if (_isJumping && _jumpKeyHeld)
        {
            _myRigidBody.AddForce(Vector2.up * _jumpForce * _myRigidBody.mass, ForceMode2D.Impulse);

            //se soltou o botão do pulo
            if (!_jumpKeyHeld && Vector2.Dot(_myRigidBody.velocity, Vector2.up) > 0)
            {
                _myRigidBody.AddForce(_counterJumpForce * _myRigidBody.mass);

            }

            _isJumping = false;
        }
    }

    public static float CalculateJumpForce(float gravityStrength, float _jumpHeight)
    {
        return Mathf.Sqrt(2 * gravityStrength * _jumpHeight);
    }

    private void Move()
    {
        _myRigidBody.AddForce(_movement * _movementSpeed, ForceMode2D.Force);
    }
}
