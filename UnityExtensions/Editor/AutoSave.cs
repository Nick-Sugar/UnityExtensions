using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class AutoSave : EditorWindow
{
    int StorageInterval = 0;
    string fileName = "FileName";
    bool on;


    [MenuItem("Tools/AutoSave")]
    static void Create()
    {
        // 生成
        GetWindow<AutoSave>("設定");
    }
    [MenuItem("Tools/Test")]
    void ExampleOnGUI()
    {
        EditorGUILayout.ToggleLeft("save prefab", on);
    }
    public void OnGUI()
    {
        
        EditorGUILayout.ToggleLeft("save prefab", on);
        fileName = EditorGUILayout.TextField("File Name:", fileName);
        //　hpシリアライズデータを表示
        EditorGUILayout.IntSlider(StorageInterval, 0, 100);

        if (GUILayout.Button("Save"))
        {
            seve();
        }
    }
    void seve()
    {
        bool check = EditorSceneManager.SaveScene(EditorSceneManager.GetActiveScene());
        Debug.Log("AutoSave" + (check ? "OK" : "Error"));
    }
    static AutoSave()
    {
        EditorApplication.playModeStateChanged += LogPlayModeState;
    }
    private static void LogPlayModeState(PlayModeStateChange state)
    {
        Debug.Log(state);
    }
}
