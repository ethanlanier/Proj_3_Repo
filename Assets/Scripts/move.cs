using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public CharacterController cc;
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity = -4f;

    public float verticalSpeed;

    void Update()
    {
        Vector3 movement = Vector3.zero;

        //horizontal/forward movement
        float forwardMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float horizontalMove = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        movement += (transform.forward * forwardMove) + (transform.right * horizontalMove);

        //jump only if on ground
        if (cc.isGrounded)
        {
            verticalSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = jumpSpeed;
            }
        }

        //player affected by gravity
        verticalSpeed += gravity * Time.deltaTime;
        movement += (transform.up * verticalSpeed * Time.deltaTime);

        cc.Move(movement);
    }
}
