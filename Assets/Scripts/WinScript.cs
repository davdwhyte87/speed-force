using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    public GameObject winScreen;
    public ScoreHandler scoreHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Win()
    {
        //PlayerMovement.doMove = false;
        scoreHandler.EndGame();

        //Right now winners are curretnly added to leaderboard according to that EndGame func you just called
        winScreen.SetActive(true);
    }

    public void PlayVictorySound()
    {
        FindObjectOfType<SoundManager>().Play("VictorySound");
    }

    public void MainMenu()
    {
        //Take them back to main menu
    }
}
