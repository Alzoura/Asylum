using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Image StaminaBarImage;
    public GameObject Player;

    void Update()
    {
        PlayerMovement PM = Player.GetComponent<PlayerMovement>();
        StaminaBarImage.fillAmount = Mathf.Clamp(PM.stamina / 100, 0, 1f);
    }
}
