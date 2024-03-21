using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    int oxyLevel = 0;
    public Slider slider;
    public Transform submarine; // R�f�rence � l'objet repr�sentant le sous-marin

    void Update()
    {
        // V�rifiez la position du sous-marin en y
        if (submarine.position.y < 3f)
        {
            UpdateOxygen(); // Augmentez le niveau d'oxyg�ne
        }
    }

    public void UpdateOxygen()
    {
        oxyLevel--;
        slider.value = oxyLevel;
    }
}
