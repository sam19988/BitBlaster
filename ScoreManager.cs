using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{

    public Text ScoreText;
    public int score = 0;
    public int highScore=0;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("highScore"))
        {
            if (PlayerPrefs.GetInt("highScore") == 0)
                PlayerPrefs.SetInt("highScore", score);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
        if (score > highScore)
        {
            SetHighScore();
        }
    }

    public void SetHighScore()
    {
        if (PlayerPrefs.GetInt("highScore") < score)
            PlayerPrefs.SetInt("highScore", score);
    }
}
