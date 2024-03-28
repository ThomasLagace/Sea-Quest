using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionRequins : MonoBehaviour
{
    public GameObject requinPrefab;
    public float vitesseMin = 1f;
    public float vitesseMax = 5f;
    public float apparitionInterval = 5f;
    public float hauteurMin = -4.5f;
    public float hauteurMax = 4.5f;
    public float positionDepartX = 10f;
    public float positionDestructionX = -10f;

    private List<float> positionsXUtilisees = new List<float>();

    void Start()
    {
        // Lancer la génération de requins
        InvokeRepeating("GenererRequin", 0f, apparitionInterval);
    }

    void GenererRequin()
    {
        // Déterminer aléatoirement si le requin vient de la gauche ou de la droite
        bool spawnVersLaGauche = (Random.Range(0, 2) == 0);

        // Générer une nouvelle position X
        float nouvellePosX = GenererNouvellePositionX();

        // Créer une copie du requin
        GameObject requinClone = Instantiate(requinPrefab, new Vector3(nouvellePosX, Random.Range(hauteurMin, hauteurMax), 0f), Quaternion.identity);

        // Récupérer le composant SharkMvt
        SharkMvt sharkMvt = requinClone.GetComponent<SharkMvt>();
        if (sharkMvt != null)
        {
            // Ajuster la direction de déplacement du requin
            sharkMvt.AjusterDirectionSpawn(!spawnVersLaGauche);
        }

        // Vérifier si le requin a un Rigidbody2D
        Rigidbody2D rigidbodyRequin = requinClone.GetComponent<Rigidbody2D>();
        if (rigidbodyRequin != null)
        {
            // Assigner la vélocité
            float vitesse = spawnVersLaGauche ? -Random.Range(vitesseMin, vitesseMax) : Random.Range(vitesseMin, vitesseMax);
            rigidbodyRequin.velocity = new Vector2(vitesse, 0f);
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
                // Retirer la position X utilisée de la liste
                positionsXUtilisees.Remove(requin.position.x);

                // Détruire le requin
                Destroy(requin.gameObject);
            }
        }

        // Nettoyer la liste des positions X utilisées
        positionsXUtilisees.RemoveAll(x => x < positionDestructionX);
    }
}
