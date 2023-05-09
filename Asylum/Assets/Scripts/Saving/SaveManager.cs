using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveLoad.Runtime
{
    public static class SaveManager
    {
        private static readonly string saveFolder = Application.persistentDataPath + "/GameData";

        public static void Delete(string profileName)
        {
            if (!File.Exists($"{saveFolder}/{profileName}"))
            {
                throw new Exception($"Save Profile {profileName} not found.");
            }
            Debug.Log($"Successfully deleted {saveFolder}/{profileName}");
            File.Delete($"{saveFolder}/{profileName}");
        }

        public static SaveProfile<T> Load<T>(string profileName) where T : SaveProfileData
        {
            if (!File.Exists($"{saveFolder}/{profileName}"))
            {
                throw new Exception(($"Save Profile {saveFolder}/{profileName} not found"));
            }

            var fileContents = File.ReadAllText(($"{saveFolder}/{profileName}"));
            Debug.Log(($"Successfully Loaded {saveFolder}/{profileName}"));
            return JsonConvert.DeserializeObject<SaveProfile<T>>(fileContents);
        }

        public static void Save<T>(SaveProfile<T> save) where T : SaveProfileData
        {
            /*if (File.Exists($"{saveFolder}/{save.name}"))
            {
                throw new Exception($"Save Profile {saveFolder}/{save.name}already exists.");
            }*/

            var jsonString = JsonConvert.SerializeObject(save, Formatting.Indented,
                    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            if (!Directory.Exists(saveFolder))
                Directory.CreateDirectory(saveFolder);
            File.WriteAllText($"{saveFolder}/{save.name}", jsonString);
        }
    }
}
