using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenLock : MonoBehaviour
{
    static public bool deathscreen = false;
    void Update()
    {

        /*Scene currentScene = SceneManager.GetActiveScene();
        string scenename = currentScene.name;
        if (scenename == "Deathscreen")*/
        if(deathscreen)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
