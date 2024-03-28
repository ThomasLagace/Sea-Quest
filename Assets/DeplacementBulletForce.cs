using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementBulletForce : MonoBehaviour
{
    public float force = 250;

    void Start()
    {
        // Si l'objet n'est pas le modèle de base (donc une copie)
        if (this.transform.name != "Bullet")
        {
            Rigidbody2D rb = this.transform.GetComponent<Rigidbody2D>();
            // Ajout de la force seulement en direction horizontale (X)
            rb.AddForce(Vector2.right * force, ForceMode2D.Impulse);
            rb.gravityScale = 0; // Désactiver la gravité
        }
    }
}
