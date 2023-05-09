using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SaveLoad.Runtime
{
    public sealed class SaveProfile<T> where T : SaveProfileData
    {
        public string name;
        public T saveData;

        private SaveProfile() { }

        public SaveProfile(string name, T saveData)
        {
            this.name = name;
            this.saveData = saveData;
        }
    }

    public abstract record SaveProfileData { }

    public record PlayerSaveData : SaveProfileData
    {
        public float ammo;
        
        public float rags;
        public float alcohol;
        public float bandages;
        
        public float sanity;

        public Vector3 position;
    }
}
