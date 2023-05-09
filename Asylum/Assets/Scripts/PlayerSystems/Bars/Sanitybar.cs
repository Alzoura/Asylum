using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanitybar : MonoBehaviour
{
    public Image SanityBarImage;
    public GameObject Player;

    void Update()
    {
        Sanity S = Player.GetComponent<Sanity>();
        SanityBarImage.fillAmount = Mathf.Clamp(S.sanity / 1000, 0, 1f);
    }
}
