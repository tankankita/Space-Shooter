using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool isPaused;
    public Canvas pauseMenu;
    public Canvas gameOverMenu;
    public int gameScore;
    public TextMeshProUGUI scoreText;



    void Start()
    {
        LoadGameData();
        HighScoreController.instance.SetHighScoreText();
    }

    public void LoadGameData()
    {
        GameData data = GameDataIO.LoadGameData();
        if(data != null)
        {
            HighScoreController.instance.highScores = data.savedHighScores;
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.gameObject.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }        
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        gameOverMenu.gameObject.SetActive(true);
        HighScoreController.instance.AddHighScore(gameScore);
        SaveGameData();
    }

    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateScore(int value)
    {
        gameScore += value;
        scoreText.text = gameScore.ToString();
    }

    public void SaveGameData()
    {
        GameData data = new GameData()
        {
            savedHighScores = HighScoreController.instance.highScores
        };

        GameDataIO.SaveGameData(data);
    }
}
