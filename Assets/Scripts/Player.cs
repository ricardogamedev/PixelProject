using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     Ver se faz sentido colocar o movimento na mesma lógica do jump

    Debugar pulo responsivo

    Dá pra mudar a gravidade usando o Y, se o valor for negativo está caindo!!!

    Como eu pulo usando o Impulse, a força é aplicada em um quadro. Então se o plasyer solta o botão, posso usar a gravidade para descer o player do pulo
     */

    [SerializeField] private Rigidbody2D _myRigidBody;
    [SerializeField] public float speed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;
    private bool isJumping = false;

    [Header("Timer")]
    [SerializeField] private float jumpTimer = 1f;
    [SerializeField] private float timer;

    private bool startTimer = false;

    private bool _pressedJump = false;
    private bool _releasedJump = false;
    private bool _isMoving = false;

    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        timer = jumpTimer;
    }

    private void Update()
    {
        CheckIfMoving();
        CheckIfJumping();

    }

    private void FixedUpdate()
    {
        if (isJumping)
        {
            StartJump();
        }
        if (_releasedJump)
        {
            StopJump();
        }
    }

    public void CheckIfJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            //  Debug.Log(isJumping);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            //  Debug.Log(isJumping);
        }
        if (startTimer)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                _releasedJump = true;
            }
        }
    }

    public void CheckIfMoving()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _myRigidBody.AddForce(transform.right * speed, ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _myRigidBody.AddForce(-transform.right * speed, ForceMode2D.Force);

        }

    }

    public void StartJump()
    {
        _myRigidBody.gravityScale = 0;
        _myRigidBody.AddForce(transform.up * _jumpForce, ForceMode2D.Impulse);
        _pressedJump = false;
        startTimer = true;
       // Debug.Log(_myRigidBody.gravityScale);
    }

    public void StopJump()
    {
        _myRigidBody.gravityScale = _gravityScale;
        _releasedJump = false;
        timer = jumpTimer;
        startTimer = false;
        Debug.Log(startTimer);
    }

}
