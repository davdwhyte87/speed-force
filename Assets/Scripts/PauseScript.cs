using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject countDown;
    public GameObject speedForceNotifyText;
    public GameObject pauseMenu;
    public GameObject pauseButton;
    public GameObject scoreText;
    public GameObject jewelText;
    public GameObject jewelImage;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject abilityActivateButton;
    public GameObject setTurtleTime;
    public GameObject setPhasing;
    public GameObject setEnergyBlast;
    public GameObject yesAutoActivateAbilityButton;
    public GameObject noAutoActivateAbilityButton;
    public PowerupHandler powerupHandler;
    public Text pauseRemainingDistance;

    bool autoActivateAbility;

    void Start(){
        //No need here, I'm already doingthis each time the game is paused
        //autoActivateAbility = false;
        SetPauseCurrentAbilityUI();
    }


    public void Pause(){
        //Should I be doing this? I think so
        autoActivateAbility = false;
        SetPauseAutoActivateAbilityUI();

        FindObjectOfType<SoundManager>().Play("ButtonSound");
        pauseRemainingDistance.text = "Distance Left: " + ScoreHandler.remainingDistance.ToString("0000") + "m";
        pauseMenu.SetActive(true);
        speedForceNotifyText.GetComponent<Text>().enabled = false;
        jewelText.SetActive(false);
        jewelImage.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
        pauseButton.SetActive(false);
        abilityActivateButton.SetActive(false);
        Time.timeScale = 0f;
        scoreText.SetActive(false);
    }

    public void UnPause(){
        
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        StartCoroutine("Continue");
    }

    IEnumerator Continue(){
        pauseMenu.SetActive(false);
        countDown.SetActive(true);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
        
        yield return new WaitForSecondsRealtime(3f);

        jewelText.SetActive(true);
        jewelImage.SetActive(true);
        
        speedForceNotifyText.GetComponent<Text>().enabled = true;
        abilityActivateButton.SetActive(true);
        pauseButton.SetActive(true);
        scoreText.SetActive(true);
        countDown.SetActive(false);

        Time.timeScale = 1f;

        if(autoActivateAbility)
            powerupHandler.ActivateAbility();
    }

    void SetPauseCurrentAbilityUI()
    {
        powerupHandler.SetActivateAbilityButton();
        powerupHandler.SetAbilityCountUI();
        SetPauseAutoActivateAbilityUI();

        Text[] abilityText;

        if (PowerupHandler.currentAbility == PowerupHandler.Ability.TurtleTime)
        {
            abilityText = setTurtleTime.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.green;
            abilityText[1].color = Color.green;

            abilityText = setPhasing.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.black;
            abilityText[1].color = Color.black;

            abilityText = setEnergyBlast.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.black;
            abilityText[1].color = Color.black;
 
        }
        else if (PowerupHandler.currentAbility == PowerupHandler.Ability.Phasing)
        {
            abilityText = setTurtleTime.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.black;
            abilityText[1].color = Color.black;

            abilityText = setPhasing.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.yellow;
            abilityText[1].color = Color.yellow;

            abilityText = setEnergyBlast.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.black;
            abilityText[1].color = Color.black;
        }
        else if (PowerupHandler.currentAbility == PowerupHandler.Ability.EnergyBlast)
        {
            abilityText = setTurtleTime.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.black;
            abilityText[1].color = Color.black;

            abilityText = setPhasing.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.black;
            abilityText[1].color = Color.black;

            abilityText = setEnergyBlast.GetComponentsInChildren<Text>();
            abilityText[0].color = Color.red;
            abilityText[1].color = Color.red;
        }
    }

    private void SetPauseAutoActivateAbilityUI()
    {
        ColorBlock colorBlock;
        Button btnYes = yesAutoActivateAbilityButton.GetComponent<Button>();
        Button btnNo = noAutoActivateAbilityButton.GetComponent<Button>();

        if(PowerupHandler.canUseAbility)
            btnYes.interactable = true;
        else
            btnYes.interactable = false;

        if (autoActivateAbility)
        {
            colorBlock = btnYes.colors;
            colorBlock.normalColor = new Color32(0, 245, 229, 255);
            colorBlock.selectedColor = new Color32(0, 245, 229, 255);
            btnYes.colors = colorBlock;

            colorBlock = btnNo.colors;
            colorBlock.normalColor = new Color32(255, 255, 255, 255);
            colorBlock.selectedColor = new Color32(255, 255, 255, 255);
            btnNo.colors = colorBlock;
        }
        else
        {
            colorBlock = btnNo.colors;
            colorBlock.normalColor = new Color32(0, 245, 229, 255);
            colorBlock.selectedColor = new Color32(0, 245, 229, 255);
            btnNo.colors = colorBlock;

            colorBlock = btnYes.colors;
            colorBlock.normalColor = new Color32(255, 255, 255, 255);
            colorBlock.selectedColor = new Color32(255, 255, 255, 255);
            btnYes.colors = colorBlock;
        }
    }

    public void SetTurtleTimeActive()
    {
        PowerupHandler.currentAbility = PowerupHandler.Ability.TurtleTime;
        SetPauseCurrentAbilityUI();
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }

    public void SetPhasingActive()
    {
        PowerupHandler.currentAbility = PowerupHandler.Ability.Phasing;
        SetPauseCurrentAbilityUI();
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }

    public void SetEnergyBlastActive()
    {
        PowerupHandler.currentAbility = PowerupHandler.Ability.EnergyBlast;
        SetPauseCurrentAbilityUI();
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }

    public void YesAutoActivateAbility()
    {
        autoActivateAbility = true;
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SetPauseAutoActivateAbilityUI();
    }

    public void NosAutoActivateAbility()
    {
        autoActivateAbility = false;
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SetPauseAutoActivateAbilityUI();
    }
}
