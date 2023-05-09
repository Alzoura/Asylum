using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetect : MonoBehaviour
{
    public float range = 5f;
    public Camera fpsCam;

    void Update()
    {
        if (Input.GetButtonDown("Activate"))
        {
            Detect();
        }
    }

    void Detect()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            AmmoPickup AP = hit.transform.GetComponent<AmmoPickup>();
            RagsPickup RP = hit.transform.GetComponent<RagsPickup>();
            AlcoholPickup AcP = hit.transform.GetComponent<AlcoholPickup>();
            if (AP != null)
            {
                AP.Ammo();
            }
            if (RP != null)
            {
                RP.Rags();
            }
            if (AcP != null)
            {
                AcP.Alcohol();
            }
        }
    }
}
