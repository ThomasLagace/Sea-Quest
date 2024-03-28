using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D�truireSousAxeX : MonoBehaviour
{
    public float minX = -9f; // X minimum pour la destruction
    public float maxX = 9f; // X maximum pour la destruction

    void Update()
    {
        // V�rifier si la position X est en dehors des limites
        if (transform.position.x < minX || transform.position.x > maxX)
        {
            // Destruction de l'objet
            Destroy(gameObject);
        }
    }
}
