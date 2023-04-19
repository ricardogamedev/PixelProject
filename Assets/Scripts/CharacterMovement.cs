using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{ /*
     Dá pra mudar a gravidade usando o Y, se o valor for negativo está caindo!!!

    Como eu pulo usando o Impulse, a força é aplicada em um quadro. Então se o plasyer solta o botão, posso usar a gravidade para descer o player do pulo
  */
    public Rigidbody2D _myRigidBody;
    [SerializeField] private float _moveSpeed = 10f;
    [SerializeField] private float _jumpForce = 10f;
    private Vector2 myVector2;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

        }
    }

    private void FixedUpdate()
    {

    }



}
