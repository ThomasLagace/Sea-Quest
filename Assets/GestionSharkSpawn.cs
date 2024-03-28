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
        // Lancer la g�n�ration de requins
        InvokeRepeating("GenererRequin", 0f, apparitionInterval);
    }

    void GenererRequin()
    {
        // D�terminer al�atoirement si le requin vient de la gauche ou de la droite
        bool spawnVersLaGauche = (Random.Range(0, 2) == 0);

        // G�n�rer une nouvelle position X
        float nouvellePosX = GenererNouvellePositionX();

        // Cr�er une copie du requin
        GameObject requinClone = Instantiate(requinPrefab, new Vector3(nouvellePosX, Random.Range(hauteurMin, hauteurMax), 0f), Quaternion.identity);

        // R�cup�rer le composant SharkMvt
        SharkMvt sharkMvt = requinClone.GetComponent<SharkMvt>();
        if (sharkMvt != null)
        {
            // Ajuster la direction de d�placement du requin
            sharkMvt.AjusterDirectionSpawn(!spawnVersLaGauche);
        }

        // V�rifier si le requin a un Rigidbody2D
        Rigidbody2D rigidbodyRequin = requinClone.GetComponent<Rigidbody2D>();
        if (rigidbodyRequin != null)
        {
            // Assigner la v�locit�
            float vitesse = spawnVersLaGauche ? -Random.Range(vitesseMin, vitesseMax) : Random.Range(vitesseMin, vitesseMax);
            rigidbodyRequin.velocity = new Vector2(vitesse, 0f);
        }
        else
        {
            // Si le Rigidbody2D est manquant, afficher un message d'erreur
            Debug.LogError("Le Rigidbody2D est manquant sur le requin.");
        }

        // Ajouter la nouvelle position X utilis�e � la liste
        positionsXUtilisees.Add(nouvellePosX);
    }

    float GenererNouvellePositionX()
    {
        float nouvellePosX;

        // G�n�rer une nouvelle position X jusqu'� ce qu'elle ne soit pas utilis�e
        do
        {
            nouvellePosX = Random.Range(positionDepartX, positionDepartX + 5f); // Ajustez la plage selon vos besoins
        } while (positionsXUtilisees.Contains(nouvellePosX));

        return nouvellePosX;
    }

    void Update()
    {
        // V�rifier si les requins atteignent la position de destruction
        foreach (Transform requin in transform)
        {
            if (requin.position.x < positionDestructionX)
            {
                // Retirer la position X utilis�e de la liste
                positionsXUtilisees.Remove(requin.position.x);

                // D�truire le requin
                Destroy(requin.gameObject);
            }
        }

        // Nettoyer la liste des positions X utilis�es
        positionsXUtilisees.RemoveAll(x => x < positionDestructionX);
    }
}
