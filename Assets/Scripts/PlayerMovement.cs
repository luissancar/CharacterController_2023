using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController player;

    private float horizontalMove;
    private float verticalMove;
    public float playerSpeed=10;
    private Vector3 playerInput;
    
    //Gravity
    public float gravity = 9.8f;
    public float fallVelocity;


    //Camara
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePlayer;

    private void Start()
    {
        player=GetComponent<CharacterController>();
    }
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        //Movimiento
        horizontalMove=Input.GetAxis("Horizontal");
        verticalMove= Input.GetAxis("Vertical");
        
        playerInput =new Vector3(horizontalMove, 0,verticalMove);
        playerInput=Vector3.ClampMagnitude(playerInput, 1);  /// en diagonal misma velocidad
        //player.Move(playerInput* Time.deltaTime);


        //Camara
        CamDirection();
        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        movePlayer = movePlayer * playerSpeed;  // aislamos la velocidad horizontal frontal de la gravedad
        player.transform.LookAt(player.transform.position + movePlayer);

        SetGravity();
        
        player.Move(movePlayer * Time.deltaTime);

    }

    private void CamDirection()
    {
        camForward=mainCamera.transform.forward;
        camRight=mainCamera.transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }


    private void SetGravity()
    {
        if (player.isGrounded)
        {
            fallVelocity = -gravity * Time.deltaTime ;
            movePlayer.y = -fallVelocity;
        }
        else
        {
            fallVelocity -= gravity * Time.deltaTime ;  //acelera
            movePlayer.y = -fallVelocity;
        }
       
    }
}
