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
        scoreText = GetComponent<Text>();
        gameSession = FindObjectOfType<GameSession>();
    }

    void Update()
    {
        scoreText.text = gameSession.GetScore().ToString();
        if(gameSession.GetScore() > total)
        {
            FindObjectOfType<Level>().LoadWinner();
        }
    }


}
