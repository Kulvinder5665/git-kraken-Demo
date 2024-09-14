using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> tragets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI livesText;
    public int score;
    public Button restartButton;
    public bool isGameActive;
    public GameObject titleScreen;
    public GameObject pausedScreen;
  
    public bool isPaused;
    public int lives;
    
    //private 

    private float spawnRate=1.0f;
    public static int count = 0;


     void Update()
    {
        if (isGameActive)
        {
          
            if (Input.GetKeyDown(KeyCode.P))
            {
                ChangedPaused();
            }
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd; 
        scoreText.text = "Score : "+ score;
    }

 

    public void GameOver()
    {
       
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }


    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty){
        titleScreen.gameObject.SetActive(false);

        livesText.gameObject.SetActive(true);
       
        isGameActive = true;
        spawnRate = spawnRate / difficulty;
        score = 0;
        StartCoroutine(SpawnTraget());
        UpdateScore(0);
        UpdateLives(3);


    }

    public void ChangedPaused()
    {
        if (!isPaused)
        {
            isPaused = true;
            pausedScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            pausedScreen.SetActive(false);
            Time.timeScale = 1;
        }
       // ResumeButton();
    }

    IEnumerator SpawnTraget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, tragets.Count);
            Instantiate(tragets[index]);

        }
    }

    //life code

    public void UpdateLives(int livesToChange)
    {
        lives += livesToChange;
        Debug.Log("Lives changed by: " + livesToChange + ". New lives: " + lives);
        livesText.text = "Lives: " + lives;
        if (lives <= 0)
        {
            GameOver();
        }
    }

    // Pused Plane

    public void ResumeButton()
    {
        isPaused = false;
        pausedScreen.SetActive(false);
        Time.timeScale = 1;
    }
}
