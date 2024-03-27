using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class GestionSharkSpawn : MonoBehaviour
{
    public GameObject requinPrefab;
    public float vitesseMin = 1f;
    public float vitesseMax = 5f;
    public float tailleMin = 0.1f;
    public float tailleMax = 1f;
    public float apparitionInterval = 5f;
    public float hauteurMin = -4.5f;
    public float hauteurMax = 4.5f;
    public float positionDepartX = 10f;
    public float positionDestructionX = -10f;

    private List<float> positionsXUtilisees = new List<float>();

    void Start()
    {
        InvokeRepeating("GenererRequin", 0f, apparitionInterval);
    }

    void GenererRequin()
    {
        float nouvellePosX = GenererNouvellePositionX();

        GameObject requinClone = Instantiate(requinPrefab, new Vector3(nouvellePosX, Random.Range(hauteurMin, hauteurMax), 0f), Quaternion.identity);

        // Vérifier si le requin a un Rigidbody2D
        Rigidbody2D rigidbodyRequin = requinClone.GetComponent<Rigidbody2D>();
        if (rigidbodyRequin != null)
        {
            // Assigner la vitesse
            rigidbodyRequin.velocity = new Vector2(Random.Range(vitesseMin, vitesseMax), 0f);
        }
        else
        {
            // Si le Rigidbody2D est manquant, afficher un message d'erreur
            Debug.LogError("Le Rigidbody2D est manquant sur le requin.");
        }

        // Ajouter la nouvelle position X utilisée à la liste
        positionsXUtilisees.Add(nouvellePosX);
    }

    float GenererNouvellePositionX()
    {
        float nouvellePosX;

        // Générer une nouvelle position X jusqu'à ce qu'elle ne soit pas utilisée
        do
        {
            nouvellePosX = Random.Range(positionDepartX, positionDepartX + 5f); // Ajustez la plage selon vos besoins
        } while (positionsXUtilisees.Contains(nouvellePosX));

        return nouvellePosX;
    }

    void Update()
    {
        // Vérifier si les requins atteignent la position de destruction
        foreach (Transform requin in transform)
        {
            if (requin.position.x < positionDestructionX)
            {
                positionsXUtilisees.Remove(requin.position.x);

                Destroy(requin.gameObject);
            }
        }
    }
}
