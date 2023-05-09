using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholPickup : MonoBehaviour
{
    public GameObject Player;

    public void Alcohol()
    {
        Inventory I = Player.GetComponent<Inventory>();
        I.Alcohol += 1;
        I.SetAlcoholCount();
        Destroy(gameObject);
    }
}

