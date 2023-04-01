using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject saveMeMenu;
    public ScoreHandler scoreHandler;
    public Transform player;
    public GameObject scoreText;
    public GameObject gemsText;
    public GameObject gemsImage;
    public GameObject abilityActivateButton;
    public GameObject pauseButton;
    public GameObject leftButton;
    public GameObject rightButton;
    private Shop shop;

    private Animator animator;

    public GameObject playerTrail;


    public void Retry()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("GameScene");
    }

    void Start()
    {

        animator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    public void Menu()
    {
        Time.timeScale = 1;
        PowerupHandler.hasClickedMenu = true;
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        shop = SaveSystem.LoadShopData();
    }

    public void SaveMe()
    {
        playerTrail.SetActive(true);
        scoreText.SetActive(true);
        gemsText.SetActive(true);
        gemsImage.SetActive(true);

        animator.SetBool("IsDead", false);
        animator.SetBool("IsFalling", false);
        FindObjectOfType<SoundManager>().Play("PowerupPickupSound");
        player.position = new Vector3(0, 0.7f, player.position.z);


        saveMeMenu.SetActive(false);
        abilityActivateButton.SetActive(true);
        pauseButton.SetActive(true);

        leftButton.SetActive(true);
        rightButton.SetActive(true);
        PlayerMovement.doMove = true;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].transform.position.z > player.position.z && objs[i].transform.position.z < player.position.z + 50)
            {
                Destroy(objs[i]);
            }
        }

        GameObject[] objs2 = GameObject.FindGameObjectsWithTag("Guardian");
        for (int i = 0; i < objs2.Length; i++)
        {
            if (objs2[i].transform.position.z > player.position.z - 60 && objs2[i].transform.position.z < player.position.z + 60)
            {
                Destroy(objs2[i]);
            }
        }






    }

    public void DontSaveMe()
    {

        scoreHandler.EndGame();

        FindObjectOfType<SoundManager>().Play("ButtonSound");
        saveMeMenu.SetActive(false);

        gameOverMenu.SetActive(true);

    }



}
