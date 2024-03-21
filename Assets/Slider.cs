using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    int oxyLevel = 0;
    public Slider slider;
    public Transform submarine; // Référence à l'objet représentant le sous-marin

    void Update()
    {
        // Vérifiez la position du sous-marin en y
        if (submarine.position.y < 3f)
        {
            UpdateOxygen(); // Augmentez le niveau d'oxygène
        }
    }

    public void UpdateOxygen()
    {
        oxyLevel--;
        slider.value = oxyLevel;
    }
}
