using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string nom)
    {
        SceneManager.LoadScene(nom);
    }

    public void UnloadScene(string nom)
    {
        SceneManager.UnloadSceneAsync(nom);
    }

    public void QuitGame()
    {
        Debug.Log("Quitter l'application.");
        Application.Quit();
    }
}
