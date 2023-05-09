using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public GameObject AmmoHolder;

    public void Ammo()
    {
        Gun G = AmmoHolder.GetComponent<Gun>();
        G.ammo += 5;
        G.SetAmmoCount();
        Destroy(gameObject);
    }
}
