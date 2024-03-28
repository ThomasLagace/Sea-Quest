using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMPro.TMP_Text texteCompteur;
    public int compteur;

    void Start()
    {
        texteCompteur.text = $"{compteur}";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            compteur+=20;
            texteCompteur.text = $"{compteur}";
        }
    }
}
