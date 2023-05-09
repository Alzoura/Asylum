using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Invoke("SeePlayer", 1f);
        }
    }

    void SeePlayer()
    {
        GetComponentInParent<EnemySystem>().detect();
        
        //Detected = true;
        //Seen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponentInParent<EnemySystem>().unsee();
            
            //Seen = false;
        }
    }

    void Update()
    {
        EnemySystem ES = GetComponentInParent<EnemySystem>();
        ES.Hiding -= 1 * Time.deltaTime;

        if (ES.Seen == true)
        {
            ES.Hiding = 10;
            
        }
        if (ES.Hiding <= 0)
        {
            GetComponentInParent<EnemySystem>().undetect();
            
            //Detected = false;
        }
    }
}
