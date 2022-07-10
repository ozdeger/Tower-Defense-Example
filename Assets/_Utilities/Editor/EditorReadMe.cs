using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.EditorApplication;

[InitializeOnLoad]
public static class EditorReadMe
{
    static EditorReadMe()
    {
        EditorApplication.update += OpenEditorReadMeWindowOnEditorLaunch;
    }
    
    public static void OpenEditorReadMeWindowOnEditorLaunch()
    {
        EditorApplication.update -= OpenEditorReadMeWindowOnEditorLaunch;
        if (!SessionState.GetBool("FirstInitDone", false))
        {
            EditorWindow.GetWindow<EditorReadMeWindow>();
            SessionState.SetBool("FirstInitDone", true);
        }
    }
}

public class EditorReadMeWindow : EditorWindow
{
    private void OnEnable()
    {
        position = new Rect(300, 200, 1200, 400);
    }

    private void OnDisable()
    {
        EditorApplication.Beep();
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 1200, 150),
           "Most Settings Can be configured from the 'Level Config' scriptable object in Resources and MANAGERS/GameManager in the scene." +
           "\n" +
           "\nI have developed the game as a pluggable behaviour system which is easy to expand upon,"+
           "\nbecause most tower defense games have roguelite elements and tower upgrading these days." +
           "\nWhile developing this project i had 5 days which 3 of them was work days so i couldn't have much time to spare" +
           "\nDidn't have time to implement a saving system and dividing to project to assembly definitions yet i do have work experience on those cases as well."+
           "\n" +
           "\nScenes are saved with an editor script which can be accesed from Tools/Create Scene Pool" +
           "\n" +
           "\nHigh Score save data can be deleted from Tools/Delete Save Datas." +
           "\n" +
           "\nMore configurations can be found in the following scriptable objects:" +
           "\n-> Resources/ScriptableObjects/Behaviours" +
           "\n-> Resources/ScriptableObjects/ScenePools"+
           "\n-> Resources/ScriptableObjects/Pools");
    }
}
