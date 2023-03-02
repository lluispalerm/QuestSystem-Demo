using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace QuestSystem.SaveSystem
{
    public class SaveSytemProves : MonoBehaviour
    {
        //public QuestObjective data;
        public QuestLogSaveData data;


        public void save()
        {
            data = new QuestLogSaveData(QuestManager.GetInstance().misionLog);
            Debug.Log(data);
            QuestSaveSystem.Save("save1", data);

        }

        public void load()
        {
            /*
            QuestLogSaveData aux = QuestSaveSystem.Load(Application.persistentDataPath + "/saves/" + "save1" + ".save") as QuestLogSaveData;
            if (aux == null) Debug.Log("Ciertamente es Null " + aux);

            data = aux;
            QuestManager.GetInstance().misonLog.LoadUpdate(data);*/
            Scene scene = SceneManager.GetActiveScene();
            //SSceneManager.UnloadScene(scene.name);
            SceneManager.LoadScene(scene.name);

        }
    }
}
