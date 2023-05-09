using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject player;
    public float EnemyHP = 100;

    void Update()
    {
        if (EnemyHP <= 0)
        {
            GetComponentInChildren<EnemyHitbox>().respawnReset();
            Sanity S = player.GetComponent<Sanity>();
            S.sanity -= 75;
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    public void GetShot(float amount)
    {
        EnemyHP -= amount;
    }
}
