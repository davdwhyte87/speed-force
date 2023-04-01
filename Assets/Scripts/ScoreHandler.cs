using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using CloudOnce;

public class ScoreHandler : MonoBehaviour
{
    private Shop shop;
    public Transform playerPos;
    public Text remainingDistanceText;
    public Text gameOverScoreText;
    public Text gameOverHighScoreText;

    float distanceToAdogen;
    public static float remainingDistance;
    public int score;
    int currentHighScore;


    void Awake()
    {
        shop = SaveSystem.LoadShopData();
    }

    void Start()
    {
        //use variables, be witty and make everything nice
        //75 i.e 10 starting floors + 60 to reach Adogen + 5 spawned at this point
        distanceToAdogen = FloorHandler.distanceToAdogen;
        //InvokeRepeating("IncreaseScore", 0, .02f);
        //highScoreText.text = "High score: " + shop.highScore.ToString();
        currentHighScore = shop.highScore;

    }





    // Update is called once per frame
    void Update()
    {
        remainingDistance = distanceToAdogen - playerPos.position.z;

        //if (remainingDistance < 1) PlayerMovement.doMove = false;

        if (remainingDistance < (distanceToAdogen - currentHighScore)) remainingDistanceText.color = Color.green;
        else remainingDistanceText.color = Color.white;

        
        remainingDistanceText.text = "Distance Left: " + remainingDistance.ToString("0000") + "m";

    }

    public void EndGame()
    {

        
        score = (int)(distanceToAdogen - remainingDistance);
        if(score > distanceToAdogen)
            score = (int)distanceToAdogen;

        if (score > currentHighScore)
        {
            FindObjectOfType<SoundManager>().Play("VictorySound");
            gameOverHighScoreText.text = "New longest distance run: " + score.ToString() + "m";
            gameOverScoreText.text = "You got closer to Adogen than ever before!";
            gameOverScoreText.fontSize = 70;
            SaveSystem.SetNewHighScore(score);
            //gameOverHighScoreText.transform.position = new Vector3(0, -16, 0);
            // Leaderboards.SpeedForceHighScore.SubmitScore(score);
        }
        else
        {
            gameOverHighScoreText.text = "Longest distance run: " + shop.highScore.ToString() + "m";
            gameOverScoreText.text = "Distance ran: " + score + "m";
            gameOverScoreText.fontSize = 90;
            //gameOverHighScoreText.transform.position = new Vector3(0, -46, 0);
        }

    }
}
