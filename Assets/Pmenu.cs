using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pmenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;
    public GameObject pausedMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                    
            }
            else
            {
                Pause();
            }
        }
    } 
    
    void Resume()
    {
        pausedMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }


    void Pause()
    {
        pausedMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;

    } 
    void Exist()
    {
        Application.Quit();
    }

    
}
