using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sanity : MonoBehaviour
{
    public float sanity = 1000f;

    void Update()
    {
        Debug.Log(sanity);
        Debug.Log(Application.persistentDataPath);
    }
}


