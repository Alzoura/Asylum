using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad.Runtime
{
    public class PlayerSave : MonoBehaviour
    {
        [SerializeField] private Gun G;
        public GameObject respawner;

        void Start()
        {
            //var G = GetComponentInChildren<Gun>();
            var I = GetComponent<Inventory>();
            var S = GetComponent<Sanity>();
            Debug.Log($"G={G.ammo}");
            var playerSave = new PlayerSaveData { position = new Vector3(0, 1, 0), ammo = G.ammo, alcohol = I.Alcohol, rags = I.rags, bandages = I.Bandages, sanity = S.sanity};
            var SaveProfile = new SaveProfile<PlayerSaveData>("playerSaveData", playerSave);
            SaveManager.Save(SaveProfile);
        }

        void Update()
        {
                if (Input.GetKeyDown(KeyCode.L))
                {
                    Load();
                }

            Respawn R = respawner.GetComponent<Respawn>();
            if (R.respawning)
            {
                Load();
                R.respawning = false;
            }
        }

        void Load()
        {
            var I = GetComponent<Inventory>();
            var S = GetComponent<Sanity>();
            transform.position = (SaveManager.Load<PlayerSaveData>("playerSaveData").saveData.position);

            var data = SaveManager.Load<PlayerSaveData>("playerSaveData").saveData;
            G.ammo = data.ammo;
            I.Alcohol = data.alcohol;
            I.rags = data.rags;
            I.Bandages = data.bandages;
            S.sanity = data.sanity;
        }
    }
}
