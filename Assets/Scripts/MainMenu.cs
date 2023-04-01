using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// using CloudOnce;

public class MainMenu : MonoBehaviour
{
    Shop shop;
    public Text highScore;
    public Text jewelCount;
    public Text progressText;

    public GameObject loadingScreen;
    public GameObject infoScreen;
    public GameObject info_powerup;
    public GameObject info_credits;
    public GameObject info_howToPlay;
    public GameObject info_story;
    public Slider slider;

    private void Start()
    {
        //N: What the hell is cloud once, is it google?
        //Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        //Cloud.Initialize(false, true);
    }

    public void CloudOnceInitializeComplete()
    {
        //Not needed for this version of the game
        //Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
    }

    public void Play(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        StartCoroutine(LoadAsyncly());
        PowerupHandler.hasClickedMenu = false;
    }

    public void Store(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("PickShop");
    }

    public void Leaderboard(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }

    public void Options(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("Settings");
    }

    public void Exit(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        Application.Quit();
    }

    public void Info(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(true);
    }

    public void InfoBack(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(false);
    }

    public void InfoHowToPlay(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(false);
        info_howToPlay.SetActive(true);
    }

    public void InfoStory(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(false);
        info_story.SetActive(true);
    }

    public void InfoCredits(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(false);
        info_credits.SetActive(true);
    }

    public void InfoPowerups(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(false);
        info_powerup.SetActive(true);
    }

    public void InfoHowToPlayBack(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(true);
        info_howToPlay.SetActive(false);
    }

    public void InfoCreditsBack(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(true);
        info_credits.SetActive(false);
    }

    public void InfoPowerupBack(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(true);
        info_powerup.SetActive(false);
    }

    public void InfoStoryBack(){
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        infoScreen.SetActive(true);
        info_story.SetActive(false);
    }

    void Awake(){
        shop = SaveSystem.LoadShopData();
        highScore.text = "Longest Run: " + shop.highScore + "m";
        jewelCount.text = "" + shop.germs;
    }

    IEnumerator LoadAsyncly(){
        AsyncOperation operation = SceneManager.LoadSceneAsync("GameScene");
        loadingScreen.SetActive(true);
        while(!operation.isDone){
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100f).ToString("F0") + "%";
            yield return null;
        }
    }
}
