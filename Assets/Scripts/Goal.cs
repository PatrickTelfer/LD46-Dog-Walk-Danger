using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public static Action<string> onFinishLevel;
    public int nextSceneIndex;
    public bool loadStarted = false;
    public float time;
    private void OnTriggerEnter(Collider other)
    {
        if (loadStarted)
        {
            return;
        }

        if (other.gameObject.tag == "Dog")
        {
            GameController.win = true;
            onFinishLevel?.Invoke("");
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        loadStarted = true;


        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(time);
        GameObject[] musicPlayers = GameObject.FindGameObjectsWithTag("music");
        if (musicPlayers != null)
        {
            foreach(GameObject o in musicPlayers)
            {
                DontDestroyOnLoad(o);
            }

        }
        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        GameController.win = false;
        Time.timeScale = 1;
        yield return null;
    }
}
