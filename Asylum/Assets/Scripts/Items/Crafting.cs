using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crafting : MonoBehaviour
{
    public GameObject Player;

    public void CraftBandage()
    {
        Inventory I = Player.GetComponent<Inventory>();
        if (I.rags >= 1 && I.Alcohol >= 1)
        {
            I.rags -= 1;
            I.Alcohol -= 1;
            I.Bandages += 1;
        }
    }

    public void UseBandage()
    {
        Inventory I = Player.GetComponent<Inventory>();
        if (I.Bandages >= 1)
        {
            I.Bandages -= 1;
            HealthandDeath.health += 25;
            if (HealthandDeath.health >= 100)
            {
                HealthandDeath.health = 100;
            }
        }

    }

    public void UseRag()
    {
        Inventory I = Player.GetComponent<Inventory>();
        if (I.rags >= 1)
        {
            I.rags -= 1;
            HealthandDeath.health += 10;
            if (HealthandDeath.health >= 100)
            {
                HealthandDeath.health = 100;
            }
        }
    }
}
