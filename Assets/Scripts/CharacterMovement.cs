using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{ /*
     D� pra mudar a gravidade usando o Y, se o valor for negativo est� caindo!!!

    Como eu pulo usando o Impulse, a for�a � aplicada em um quadro. Ent�o se o plasyer solta o bot�o, posso usar a gravidade para descer o player do pulo
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
