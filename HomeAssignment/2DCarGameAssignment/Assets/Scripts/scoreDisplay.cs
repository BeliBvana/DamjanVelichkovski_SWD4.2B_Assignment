using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDisplay : MonoBehaviour
{
    Text scoreText;
    GameSession gameSession;
    int total = 100;

    void Start()
    {
        scoreText = GetComponent<Text>(); // Gets the score text
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        // If the score is bigger than the total (100) it loads the winner screen
        scoreText.text = gameSession.GetScore().ToString(); // Converts the acore to a String
        if(gameSession.GetScore() > total)
        {
            FindObjectOfType<Level>().LoadWinner();
        }
    }
}