using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using Object = UnityEngine.Object;

namespace Manatea.SceneManagement
{
    public class SceneDictionaryBuildProvider : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            SetupSceneDictionary();
            Application.logMessageReceived += OnBuildError;
        }

        private void OnBuildError(string condition, string stacktrace, LogType type)
        {
            if (condition.StartsWith("Build completed with a result"))
            {
                Application.logMessageReceived -= OnBuildError;
                CleanupSceneDictionary();
            }
        }


        private void SetupSceneDictionary()
        {
            Debug.Log("Setup scene dictionary.");

            Object dict = Resources.Load("SceneDictionary");
            SerializedObject dictSO = new SerializedObject(dict);
            SerializedProperty sceneListProp = dictSO.FindProperty("m_SceneList");
            sceneListProp.ClearArray();
            foreach (var editorScene in EditorBuildSettings.scenes)
            {
                if (!editorScene.enabled)
                    continue;

                int i = sceneListProp.arraySize;
                sceneListProp.InsertArrayElementAtIndex(i);
                SerializedProperty arrayProp = sceneListProp.GetArrayElementAtIndex(i);
                arrayProp.FindPropertyRelative("Guid").stringValue = editorScene.guid.ToString();
                arrayProp.FindPropertyRelative("Path").stringValue =  editorScene.path;
            }
            dictSO.ApplyModifiedProperties();
        }

        private void CleanupSceneDictionary()
        {
            Debug.Log("Cleanup scene dictionary.");

            Object dict = Resources.Load("SceneDictionary");
            SerializedObject dictSO = new SerializedObject(dict);
            SerializedProperty sceneListProp = dictSO.FindProperty("m_SceneList");
            sceneListProp.ClearArray();
            dictSO.ApplyModifiedProperties();
        }
    }
}
