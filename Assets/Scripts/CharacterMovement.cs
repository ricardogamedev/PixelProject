using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{ /*
     Dá pra mudar a gravidade usando o Y, se o valor for negativo está caindo!!!

    Como eu pulo usando o Impulse, a força é aplicada em um quadro. Então se o plasyer solta o botão, posso usar a gravidade para descer o player do pulo
  */
    public Rigidbody2D _myRigidBody;

    [Header("Movement Setup")]
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;

    [Header("Jump Setup")]
    [SerializeField] private float _gravityFallingModifier;
    private float _timerMaxJump = .5f;

    private bool _pressedJump = false;
    private Vector2 _movement;
    private float _timer;
    private float _horizontalInput;
    private float _verticalInput;


    private void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        _movement = new Vector2(_horizontalInput, _verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _pressedJump = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        if (_pressedJump)
        {
            _myRigidBody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);

            StartTimer();

            if (_timer >= _timerMaxJump)
            {
              //  Debug.Log("_timer -- " + _timer);
             //   Debug.Log("_jumpMaxTimer -- " + _timerMaxJump);

                _pressedJump = false;

                ResetTimer();
                //quero aumentar a gravidade quando chego no topo do pulo. Funciona mas só fica 4 por 1 frame
                //acho que falta um check de grounded
                _myRigidBody.gravityScale = 4;
                Debug.Log(_myRigidBody.gravityScale);
            }

        }
        _myRigidBody.gravityScale = 1;
        Debug.Log(_myRigidBody.gravityScale);
    }

    private void Move()
    {
        _myRigidBody.AddForce(_movement * _moveSpeed, ForceMode2D.Force);
    }

    #region Timer
    private void StartTimer()
    {
        _timer += Time.fixedDeltaTime;
    }

    private void ResetTimer()
    {
        _timer = 0;
    }

    #endregion
}
