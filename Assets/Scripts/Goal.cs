using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
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
            StartCoroutine(LoadNextScene());
        }
    }

    private IEnumerator LoadNextScene()
    {
        loadStarted = true;


        Time.timeScale = 0.3f;
        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(nextSceneIndex, LoadSceneMode.Single);
        Time.timeScale = 1;
        yield return null;
    }
}
