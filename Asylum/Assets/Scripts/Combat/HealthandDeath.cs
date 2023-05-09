using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthandDeath : MonoBehaviour
{
    static public float health = 100f;
    public GameObject deathScreen;

    private void Update()
    {
        if (health <= 0)
        {
            Invoke ("death", 0f);
        }
        if (health <= 10 && health !<=0)
        {
            Sanity S = GetComponent<Sanity>();
            S.sanity -= 1f * Time.deltaTime;
        }
    }
    public void death()
    {
        //deathScreen.SetActive(true);
        DeathScreenLock.deathscreen = true;
        SceneManager.LoadScene(0);
    }
}
