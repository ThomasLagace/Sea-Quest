using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    float oxyLevel = 0;
    public Slider slider;
    public Transform submarine;
    public float descentThreshold = 3f;
    public float decreaseSpeed = 5f;
    public float increaseSpeed = 5f;
    private PlayerController submarineFreeze;

    void Start()
    {
        submarineFreeze = submarine.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (submarine.position.y < descentThreshold)
        {
            DecreaseOxygen();
        }
        else
        {
            IncreaseOxygen();
            submarineFreeze.canMove = false;
            if (oxyLevel > 99) { submarineFreeze.canMove = true; }
        }
        if (oxyLevel <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void DecreaseOxygen()
    {
        oxyLevel -= Time.deltaTime * decreaseSpeed;
        if (oxyLevel < 0)
            oxyLevel = 0;
        slider.value = oxyLevel;
    }

    public void IncreaseOxygen()
    {
        oxyLevel += Time.deltaTime * increaseSpeed;
        if (oxyLevel > 100)
            oxyLevel = 100;
        slider.value = oxyLevel;
    }
}



