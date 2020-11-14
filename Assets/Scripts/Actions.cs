using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Actions : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("esc"))
            startGame();
        
    }

    public void startGame()
    {
        SceneManager.LoadScene("Phase1", LoadSceneMode.Single);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
