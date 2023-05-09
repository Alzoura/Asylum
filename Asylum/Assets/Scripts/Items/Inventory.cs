using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    bool inventory = false;
    public GameObject InventoryUI;
    public GameObject Blaster;
    public GameObject Rags;
    public float rags;
    public float Alcohol;
    public float Bandages;

    public TextMeshProUGUI RagsCount;
    public TextMeshProUGUI AlcoholCount;
    public TextMeshProUGUI BandageCount;

    void Update()
    {
        PlayerLook PL = GetComponentInChildren<PlayerLook>();
        Gun G = Blaster.GetComponent<Gun>();
        RagsPickup RP = Rags.GetComponentInChildren<RagsPickup>();
        if (Input.GetButtonDown("Inventory"))
        {
            if (inventory)
            {
                inventory = false;
            }
            else
            {
                inventory = true;
            }
        }

        if (inventory)
        {
            G.SetAmmoCount();
            SetBandageCount();
            SetRagsCount();
            SetAlcoholCount();
            InventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            PL.UIclosed = false;
        }
        else
        {
            InventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            PL.UIclosed = true;
        }
    }

    public void SetRagsCount()
    {
        RagsCount.text = rags.ToString();
    }

    public void SetAlcoholCount()
    {
        AlcoholCount.text = Alcohol.ToString();
    }

    public void SetBandageCount()
    {
        BandageCount.text = Bandages.ToString();
    }
}
