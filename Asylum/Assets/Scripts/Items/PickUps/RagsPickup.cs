using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagsPickup : MonoBehaviour
{
    public GameObject Player;

    public void Rags()
    {
        Inventory I = Player.GetComponent<Inventory>();
        I.rags += 1;
        I.SetRagsCount();
        Destroy(gameObject);
    }
}
