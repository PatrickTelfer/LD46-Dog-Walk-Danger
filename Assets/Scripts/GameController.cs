using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static bool win = false;
    public static void ResetLevel()
    {
        if (win)
        {
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
