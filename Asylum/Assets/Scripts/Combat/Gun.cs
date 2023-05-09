using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public float damage = 25f;
    public float range = 100f;
    public float ammo = 10f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;

    public TextMeshProUGUI ammoCount;

    void Start()
    {
        SetAmmoCount();
    }

    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ammo > 0)
        {
            muzzleFlash.Play();

            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);

                EnemyHealth EH = hit.transform.GetComponent<EnemyHealth>();
                if (EH != null)
                {
                    EH.GetShot(damage);
                }
            }
            ammo -= 1;
            SetAmmoCount();
        }
    }

    public void SetAmmoCount()
    {
        ammoCount.text = ammo.ToString();
    }
}
