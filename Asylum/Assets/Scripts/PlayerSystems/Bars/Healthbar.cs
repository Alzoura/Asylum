using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image healthBarImage;
    public GameObject Player;

    void Update()
    {
        healthBarImage.fillAmount = Mathf.Clamp(HealthandDeath.health / 100, 0, 1f);
    }
}
