using System;
using System.IO;
using DataStore;
using UnityEngine;
using Newtonsoft.Json;

namespace DataPersistence {
    // Handles conversion of data to file
    public class FileDataHandler {
        // sti til fil
        private string dataDirPath = "";

        // fil navn
        private string dataFileName = "";

        public FileDataHandler(string dataDirPath, string dataFileName) {
            this.dataDirPath = dataDirPath;
            this.dataFileName = dataFileName;
        }

        // Load fil data til gameData
        public GameData Load() {
            // use Path.Combine to account for different OS's having different path separators
            string fullPath = Path.Combine(dataDirPath, dataFileName);
            GameData loadedData = null;
            if (File.Exists(fullPath)) {
                try {
                    // load data from file to a string
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open)) {
                        using (StreamReader reader = new StreamReader(stream)) {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }

                    // deserialize the data from Json back into the C# object
                    loadedData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
                }
                catch (Exception e) {
                    Debug.LogError("Error while trying to load data from file: " + fullPath + "\n" + e);
                }
            }

            return loadedData;
        }

        // gemmer data til fil
        public void Save(GameData data) {
            // use Path.Combine to account for different OS's having different path separators
            string fullPath = Path.Combine(dataDirPath, dataFileName);
            try {
                // create the directory the file will be written to if it doesn't already exist
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                // serialize the C# game data objects into Json
                File.WriteAllText(fullPath, JsonConvert.SerializeObject(data, new JsonSerializerSettings {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
            catch (Exception e) {
                Debug.LogError("Error while trying to save data to file: " + fullPath + "\n" + e);
            }
        }
    }
}