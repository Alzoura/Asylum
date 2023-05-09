using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    bool lookat = false;
    public GameObject player;
    public Vector3 KnownPosition;
    public CharacterController EnemyController;
    public float EnemySpeed = 4f;

    public GameObject sprintingVision;
    public GameObject walkingVision;
    public GameObject stealthVision;

    public bool Detected = false;
    public bool Seen = false;
    public float Hiding = 10;

    private void Update()
    {
        if (Detected)
        {
            lookat = true;
        }

        if (Seen)
        {
            KnownPosition = player.transform.position;
        }

        if (lookat)
        {
            transform.LookAt(KnownPosition);
            if (Detected)
            {
                Vector3 move = transform.forward;
                EnemyController.Move(move * EnemySpeed * Time.deltaTime);
            }
        }

        //enemy vision fields

        if (PlayerMovement.isSprinting)
        {
            sprintingVision.SetActive(true);
            walkingVision.SetActive(false);
            stealthVision.SetActive(false);
        }
        if (PlayerMovement.isWalking)
        {
            walkingVision.SetActive(true);
            sprintingVision.SetActive(false);
            stealthVision.SetActive(false);
        }
        if (PlayerMovement.isStealthing)
        {
            stealthVision.SetActive(true);
            walkingVision.SetActive(false);
            sprintingVision.SetActive(false);
        }

        //assassinations
        AssassinationSphere AS = GetComponentInChildren<AssassinationSphere>();
        Sanity S = player.GetComponent<Sanity>();
        if (AS.assassin)
        {
            if (Input.GetButton("Activate") && AS.assassin)
            {
                Destroy(gameObject);
                S.sanity -= 50;
            }
        }
    }

    public void detect()
    {
        Detected = true;
        Seen = true;
    }

    public void undetect()
    {
        Detected = false;
    }

    public void unsee()
    {
        Seen = false;
    }
}
