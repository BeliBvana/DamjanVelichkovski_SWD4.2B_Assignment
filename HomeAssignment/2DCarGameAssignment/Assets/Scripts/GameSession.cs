using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
     public int score = 0; // So the score always starts as 0

    private void Awake()
    {
        SetUpSingleton();
    }

    // This is checking that only one GameSession is running
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score; // Gets the score value
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue; // Adds scoreValue to score
    }

    public void ResetGame()
    {
        Destroy(gameObject); // Destroys game object
    }
}