using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public GameObject Enemy;

    void Update()
    {
        EnemyHealth EH = Enemy.GetComponentInChildren<EnemyHealth>();
        PlayerHitbox PH = GetComponentInChildren<PlayerHitbox>();

        if (PH.inRange && Input.GetButtonDown("Attack"))
        {
            EH.EnemyHP -= 15;
            Debug.Log("Attack");
        }

        if (PH.inRange)
        {
            Debug.Log("InRange");
        }
    }
}
