using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace QuestSystem.SaveSystem
{
    public class QuestSaveSystem
    {
        public static string GetPath(string saveName)
        {
            return Application.persistentDataPath + "/saves/" + saveName + ".save";
        }

        public static bool Save(string saveName, object saveData)
        {
            BinaryFormatter formatter = GetBinaryFormater();

            if (!Directory.Exists(Application.persistentDataPath + "/saves"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves");
            }

            string path = GetPath(saveName);
            Debug.Log(path);
            FileStream file = File.Create(path);

            formatter.Serialize(file, saveData);
            Debug.Log("Saveado");
            file.Close();

            return true;
        }

        public static object Load(string path)
        {
            Debug.Log(path);
            if (!File.Exists(path)) return null;

            BinaryFormatter formatter = GetBinaryFormater();

            FileStream file = File.Open(path, FileMode.Open);
            try
            {
                Debug.Log("Si no se ve la patata es que peta al abrirse");
                object save = formatter.Deserialize(file);
                Debug.Log("patata");
                file.Close();
                Debug.Log("Loadeado");
                return save;
            }
            catch
            {
                Debug.LogErrorFormat("Faled to load fiale at {0}", path);
                file.Close();
                return null;
            }
        }

        public static object LoadFromName(string saveName)
        {
            return Load(GetPath(saveName));
        }

        public static BinaryFormatter GetBinaryFormater()
        {
            //Create binary formater
            BinaryFormatter formatter = new BinaryFormatter();


            //Define surrogates (especificacions de com tractar les dades)
            SurrogateSelector selector = new SurrogateSelector();

            QuestObjectiveSurrogate objectiveSurrogate = new QuestObjectiveSurrogate();
            NodeQuestSaveDataSurrogate nodeSurrogate = new NodeQuestSaveDataSurrogate();
            QuestSaveDataSurrogate questSurrogate = new QuestSaveDataSurrogate();
            QuestLogSaveDataSurrogate questLogSurrogate = new QuestLogSaveDataSurrogate();

            //selector.AddSurrogate(typeof(QuestObjective), new StreamingContext(StreamingContextStates.All), objectiveSurrogate);
            selector.AddSurrogate(typeof(NodeQuest), new StreamingContext(StreamingContextStates.All), nodeSurrogate);
            selector.AddSurrogate(typeof(Quest), new StreamingContext(StreamingContextStates.All), questSurrogate);
            selector.AddSurrogate(typeof(QuestLog), new StreamingContext(StreamingContextStates.All), questLogSurrogate);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}