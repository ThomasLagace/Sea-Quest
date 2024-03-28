using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{

    public TMPro.TMP_Text TextScore;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjouterScore(int score)
    {
        this.Score += score;
        UpdaterScore();
    }

    void UpdaterScore()
    {
        TextScore.text = $"Score: {this.Score}";
    }
}
