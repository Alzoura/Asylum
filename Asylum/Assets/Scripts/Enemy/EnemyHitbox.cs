using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : MonoBehaviour
{
    public bool inRange;
    public bool respawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }
    private void Update()
    {
        if (inRange)
        {
            Debug.Log("inRange");
        }

        if (respawn)
        {
            Invoke("respawnReset", 0f);
            respawn = false;
        }
    }

    public void respawnReset()
    {
        EnemySystem ES = GetComponentInParent<EnemySystem>();
        inRange = false;
        ES.Detected = false;
        ES.Seen = false;
    }
}
