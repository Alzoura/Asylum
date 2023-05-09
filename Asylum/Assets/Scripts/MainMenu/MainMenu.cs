using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject deathscreen;

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();
    }

    public void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        if (DeathScreenLock.deathscreen)
        {
            deathscreen.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
