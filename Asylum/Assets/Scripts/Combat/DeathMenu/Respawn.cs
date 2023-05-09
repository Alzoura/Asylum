using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject mainMenu;
    public bool respawning;

    public void respawn()
    {
        respawning = true;

        HealthandDeath.health = 100;

        SceneManager.LoadScene(1);
        CharacterController cc = player.GetComponent(typeof(CharacterController)) as CharacterController;
        cc.enabled = false;
        player.transform.position = new Vector3(0, 1, 0);
        cc.enabled = true;

        HealthandDeath HaD = player.GetComponent<HealthandDeath>();
        EnemyHitbox EHb = enemy.GetComponentInChildren<EnemyHitbox>();
        EnemySystem ES = enemy.GetComponentInChildren<EnemySystem>();

        EHb.respawn = true;
        HaD.deathScreen.SetActive(false);
        DeathScreenLock.deathscreen = false;
        Cursor.lockState = CursorLockMode.Locked;

        ES.Detected = false;
        ES.Seen = false;
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
