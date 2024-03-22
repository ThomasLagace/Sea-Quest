using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    float oxyLevel = 100;
    public Slider slider;
    public Transform submarine;
    public float descentThreshold = 3f; 
    public float decreaseSpeed = 5f; 
    public float increaseSpeed = 5f; 

    void Update()
    {
        if (submarine.position.y < descentThreshold)
        {
            DecreaseOxygen();
        }
        else
        {
            IncreaseOxygen();
        }
    }

    public void DecreaseOxygen()
    {
        oxyLevel = Mathf.Lerp(oxyLevel, 0, Time.deltaTime * decreaseSpeed); 
        slider.value = oxyLevel; 
    }

    public void IncreaseOxygen()
    {
        oxyLevel = Mathf.Lerp(oxyLevel, 100, Time.deltaTime * increaseSpeed);
        slider.value = oxyLevel; 
    }
}


