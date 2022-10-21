using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreScript : MonoBehaviour
{
    public Text scoreText;
    private int score;

    void Start()
    {
        score = 0;
        UpdateScore(0);
    }

    void Update()
    {
        UpdateScore(1);
    }
    private void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }
}