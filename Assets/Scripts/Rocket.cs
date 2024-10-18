using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    RocketDashBoard dashBoard;

    private Rigidbody2D rb2d;
    private float fuel = 100f;
    
    private readonly float SPEED = 500f;
    private readonly float FUELPERSHOOT = 10f;

   

    void Awake()
    {
        // TODO : Rigidbody2D 컴포넌트를 가져옴(캐싱) 
        rb2d = GetComponent<Rigidbody2D>();;
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
}
