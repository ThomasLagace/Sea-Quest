using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuLoader : MonoBehaviour
{
    public Canvas PauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenu.gameObject.activeSelf)
                UnpauseGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        PauseMenu.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        PauseMenu.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
