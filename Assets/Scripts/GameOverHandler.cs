using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;

    public void EndGame()
    {
        asteroidSpawner.enabled = false;

        int finalScore = scoreSystem.StopScoreCounting();

        gameOverText.text = "Game Over Score: " + finalScore;

        gameOverDisplay.gameObject.SetActive(true);
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    //public void Continue()
    //{
    //    SceneManager.LoadScene();
    //}

    
}
