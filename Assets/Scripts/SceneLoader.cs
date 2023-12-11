using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public int cena;

    public void LoadScene()
    {
        SceneManager.LoadSceneAsync(cena);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

