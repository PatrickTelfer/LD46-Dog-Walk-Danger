using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    public void StartGame ()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("settings");
        Debug.Log(objs.Length);
        foreach (GameObject o in objs)
        {
            DontDestroyOnLoad(o);
        }
        SceneManager.LoadScene(1);
    }
}
