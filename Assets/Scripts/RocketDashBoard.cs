using System.Net.Sockets;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;
using TMPro;

public class RocketDashBoard
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    int score = 0;
    Rocket rocket;

    string highScoreStr = "HighScore";
    int highscore;

    private void Awake()
    {
        GetHighScore();
        HighScoreTxt.text = $"HighScore : {highscore} M";
    }

    public void AddScore()
    {
        score = (int)rocket.transform.position.y;
        currentScoreTxt.text = $" {score} M";
    }

    public int GetHighScore()
    {
        highscore = PlayerPrefs.GetInt(highScoreStr);
        return highscore;
    }

    private void SetHighScore()
    {
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt(highScoreStr, score);
        }

    }

    public void RetryButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Update()
    {
        AddScore();
        SetHighScore();
    }

}