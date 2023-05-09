using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public float attackTimer = 2f;

    void Update()
    {
        if (HealthandDeath.health > 0)
        {
            EnemyHitbox EH = GetComponentInChildren<EnemyHitbox>();
            Sanity S = player.GetComponent<Sanity>();
            if (EH.inRange)
            {
                attackTimer -= 1 * Time.deltaTime;
                if (attackTimer <= 0 && EH.inRange)
                {
                    HealthandDeath.health -= 30;
                    S.sanity -= 20;
                    attackTimer = 1f;
                }
            }
            Debug.Log(HealthandDeath.health); 
        }
    }
}
