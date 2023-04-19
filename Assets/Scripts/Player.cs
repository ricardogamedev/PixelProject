using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
     Ver se faz sentido colocar o movimento na mesma lógica do jump
     */

    [SerializeField] private Rigidbody2D _myRigidBody;
    [SerializeField] public float speed;
    [SerializeField] private float _friction;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale = 1f;
    private bool isJumping = false;

    private float timer;
    private float jumpTimer;

    private bool _pressedJump = false;
    private bool _releasedJump = false;
    private bool _isMoving = false;

    private void Awake()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
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
        else
        {
            StopJump();
        }
    }

    public void CheckIfJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            Debug.Log(isJumping);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            Debug.Log(isJumping);
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
    }

    public void StopJump()
    {
        _myRigidBody.gravityScale = _gravityScale;
        _releasedJump = false;
        Debug.Log(_gravityScale);
    }

}

