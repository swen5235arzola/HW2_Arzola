﻿using UnityEngine;

//Author: Unity Tutorial
//Modified By: Adriana Arzola
//Date: 04/07/2019
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidBody;
    private int floorMask;
    private float camRayLength = 100f;

    public void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    ///<summary>
    ///Move the player
    ///</summary>
    ///<param value="h"></param>
    ///<param value="v"></param>
    public void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

	///<summary>
    ///Turn the player with mouse
	///</summary>
    public void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidBody.MoveRotation(newRotation);
        }
    }

    ///<summary>
    ///Animate the Player movement
    ///</summary>
    ///<param value="h"></param>
    ///<param value="v"></param>
    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
