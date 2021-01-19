using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1f;
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0); // Loads the project's first scene
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainGame"); // Loads the scene with name MainGame
        FindObjectOfType<GameSession>().ResetGame(); // Reset the game from the beginning
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad()); // Starts the coroutine WaitAndLoad()
    }

    public void LoadWinner()
    {
        StartCoroutine(WaitAndLoad2()); // Starts the coroutine WaitAndLoad2()
    }

    public void QuitGame()
    {
        Application.Quit(); // Quits the application
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds); // Does the delay
        SceneManager.LoadScene("GameOver"); // Loads the scene with name GameOver
    }

    IEnumerator WaitAndLoad2()
    {
        yield return new WaitForSeconds(delayInSeconds); // Does the delay
        SceneManager.LoadScene("Winner"); // Loads the scene with name Winner
    }
}