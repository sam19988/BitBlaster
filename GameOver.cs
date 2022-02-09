using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text scoreText;
    public Text highScoreText;

    bool isActive = false;
    ScoreManager Score;
    // Start is called before the first frame update
    void Start()
    {
        Score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            scoreText.text = "Score: " + Score.score;
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        }
    }

    public void ActivatePanel()
    {
        isActive = !isActive;
        gameOverPanel.SetActive(isActive);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
