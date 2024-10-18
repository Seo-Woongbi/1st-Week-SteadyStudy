using System.Net.Sockets;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;
using TMPro;

public class RocketDashBoard : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI highScoreTxt;

    int score = 0;
    Rocket rocket;

    string highScoreStr;
    int highscore;

    private void Awake()
    {
        rocket = GetComponent<Rocket>();
        GetHighScore();
        highScoreTxt.text = $"HighScore : {highscore} M";
    }

    public void AddScore()
    {
        score = (int)transform.position.y;
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