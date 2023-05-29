using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public string scene;

    public void startGame()
    {
        SceneManager.LoadScene(scene);
    }

    public void Quit()
    {
        Debug.Log("saiu do jogo");
        Application.Quit();
    }
}
