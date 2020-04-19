using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static bool win = false;
    public static bool paused = false;

    public void ResetLevel(int sceneIndex)
    {
        int indexToLoad = sceneIndex;
        if(indexToLoad == -1)
        {
            indexToLoad = SceneManager.GetActiveScene().buildIndex;
        }

        if (win)
        {
            return;
        }
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("HI " + indexToLoad);
            
            
            SceneManager.LoadScene(indexToLoad);
        } else
        {
            //DontDestroyOnLoad(gameObject);
            Debug.Log("Hello" + indexToLoad);

            GameObject[] musicPlayers = GameObject.FindGameObjectsWithTag("music");
            if (musicPlayers != null)
            {
                
                foreach (GameObject o in musicPlayers)
                {
                    DontDestroyOnLoad(o);
                }

            }
            SceneManager.LoadScene(indexToLoad);
        }


    }

    private void Start()
    {
     
    }

    private void Update()
    {
        // failed pause screen attempt
        /*if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            if (!paused)
            {
                pauseScreen.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                paused = true;
            } else
            {
                pauseScreen.gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1f;
                paused = false;
            }
        } */
    }


}
