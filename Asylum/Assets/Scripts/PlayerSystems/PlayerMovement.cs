using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 3f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public float stamina = 100;
    public float normalHeight = 2;
    public float crouchHeight = 1;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    static public bool isSprinting;
    static public bool isWalking;
    static public bool isStealthing;
    bool isRecovering = true;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //Sprinting and Stamina

        if (Input.GetButton("Sprint") && stamina > 0)
        {
            speed = 6f;
        }
        else
        {
            speed = 3f;
        }

        if (speed == 6f)
        {
            isSprinting = true;
            isWalking = false;
            isStealthing = false;
        }
        if (speed < 6 && speed >= 2)
        {
            isSprinting = false;
            isWalking = true;
            isStealthing = false;
        }
        if (speed < 2)
        {
            isStealthing = true;
            isWalking = false;
            isSprinting = false;
        }

        if(stamina > 100)
        {
            stamina = 100;
        }

        if(isSprinting == true)
        {
            stamina -= 25*Time.deltaTime;
        }

        if(isRecovering == true && stamina < 100 && isSprinting == false)
        {
            stamina += 10*Time.deltaTime;
        }

        if(stamina <= 0)
        {
            stamina = 0;
            speed = 2f;
            isRecovering = false;
            Invoke("Recover", 5.0f);
        }

        //Stealth/crouching

        if (Input.GetButton("Crouch"))
        {
            isStealthing = true;
        }
        else
        {
            controller.height = normalHeight;
            isStealthing = false;
        }

        if (isStealthing)
        {
            if (isRecovering == false)
            {
                speed = 1f;
            }
            else
            {
                speed = 1.8f;
            }
            controller.height = crouchHeight;
        }
        else
        {
            speed = 3f;
        }

        //Sprint and crouch again

        if (Input.GetButton("Sprint") && stamina > 0)
        {
            speed = 6f;
        }
        if (Input.GetButton("Crouch") && stamina > 0)
        {
            speed = 1.8f;
        }

    }

    void Recover()
    {
        stamina += 5*Time.deltaTime;
        isRecovering = true;
    }

}