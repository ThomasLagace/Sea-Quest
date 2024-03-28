using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SharkMvt : MonoBehaviour
{
    public float vitesse = 2f;
    private bool deplacementVersLaGauche; // Par défaut, la direction sera déterminée aléatoirement dans Start()

    void Start()
    {
        // Déterminer aléatoirement la direction initiale du déplacement
        deplacementVersLaGauche = (Random.Range(0, 2) == 0); // 0 pour gauche, 1 pour droite

        // Si le requin doit se déplacer vers la droite, ajuster sa position initiale
        if (!deplacementVersLaGauche)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(-position.x, position.y, position.z);
        }
    }

    void Update()
    {
        DeplacerRequin();
    }

    void DeplacerRequin()
    {
        Vector3 positionActuelle = transform.position;
        float deplacement = vitesse * Time.deltaTime;

        if (deplacementVersLaGauche)
        {
            // Si le requin se déplace vers la gauche
            transform.Translate(Vector3.left * deplacement);
            if (positionActuelle.x < -10f)
            {
                transform.position = new Vector3(10f, positionActuelle.y, positionActuelle.z);
            }
        }
        else
        {
            // Si le requin se déplace vers la droite
            transform.Translate(Vector3.right * deplacement);
            if (positionActuelle.x > 10f)
            {
                transform.position = new Vector3(-10f, positionActuelle.y, positionActuelle.z);
            }
        }
    }

    // Méthode pour ajuster la direction du requin en fonction du spawn
    public void AjusterDirectionSpawn(bool spawnVersLaGauche)
    {
        deplacementVersLaGauche = spawnVersLaGauche;
        if (!spawnVersLaGauche)
        {
            Vector3 position = transform.position;
            transform.position = new Vector3(-position.x, position.y, position.z);
        }
    }
}
