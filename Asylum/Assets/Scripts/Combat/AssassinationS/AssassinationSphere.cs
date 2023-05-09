using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssassinationSphere : MonoBehaviour
{
    public bool assassin;

    private void OnTriggerEnter(Collider other)
    {
        EnemySystem ES = GetComponentInParent<EnemySystem>();


        if (other.CompareTag("Player"))
        {
            if (ES.Detected == false)
            {
                assassin = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            assassin = false;
        }
    }

    void Update()
    {

    }
}
