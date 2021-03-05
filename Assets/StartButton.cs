using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button btn_gameStart;
    public string NextScene;

    public void LoadGame()
    {
        SceneManager.LoadScene(NextScene);
    }
}
