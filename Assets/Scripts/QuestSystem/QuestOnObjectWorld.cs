using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuestSystem
{
    public class QuestOnObjectWorld : MonoBehaviour
    {
        //TODO revisar
        public NodeQuest nodeQuePertenece;
        public Quest questQuePertenece;

        public GameObject[] objectsToControlList;

        private QuestManager questManagerRef;
        // Start is called before the first frame update
        void Start()
        {
            questManagerRef = QuestManager.GetInstance();
            bool activate = (questManagerRef.IsCurrent(questQuePertenece) && questQuePertenece.nodeActual == nodeQuePertenece);

            //Subscribe to observer an initialize
            for (int i = 0; i < objectsToControlList.Length; i++)
            {
                nodeQuePertenece.AddObject(objectsToControlList[i]);
                objectsToControlList[i].SetActive(activate);
            }
        }

        public void PopulateChildListDefault()
        {
            int numberOfChilds = transform.childCount;
            GameObject[] children = new GameObject[numberOfChilds];

            for (int i = 0; i < numberOfChilds; i++)
            {
                children[i] = transform.GetChild(i).gameObject;
            }

            objectsToControlList = children;
        }

    }
}