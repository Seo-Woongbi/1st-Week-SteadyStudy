using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI HighScoreTxt;

    int score = 0;
    Rocket rocket;

    private Rigidbody2D rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 500f;
    private readonly float FUELPERSHOOT = 10f;
    
    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        rb2d = GetComponent<Rigidbody2D>();
        rocket = GetComponent<Rocket>();
    }

    public void Shoot()
    {
        // TODO : fuel이 넉넉하면 윗 방향으로 SPEED만큼의 힘으로 점프, 모자라면 무시
        if (fuel >= 10f)
        {
            fuel -= FUELPERSHOOT;
            rb2d.AddForce(Vector2.up * SPEED);
        }
        else return;
    }

    public void AddScore()
    {
        score = (int)rocket.transform.position.y;
        currentScoreTxt.text = $"{score} M";
    }

    private void Update()
    {
        AddScore();
    }

    private void HighScore()
    { 

    }

    public void RetryButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
