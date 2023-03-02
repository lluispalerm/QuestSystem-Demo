using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace QuestSystem.QuestEditor
{
    [CustomEditor(typeof(QuestOnObjectWorld))]
    public class QuestOnObjectWorldEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            QuestOnObjectWorld qOW = (QuestOnObjectWorld)target;

            DrawDefaultInspector();

            if (GUILayout.Button("Populate with children"))
            {
                qOW.PopulateChildListDefault();
            }

        }
    }
}
