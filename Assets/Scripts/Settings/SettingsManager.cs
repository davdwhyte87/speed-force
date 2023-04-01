using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class SettingsManager : MonoBehaviour
{
    private Transform gameSettingsView;
    //private Button settingButton;
    //private ColorBlock colorBlock;
    // Start is called before the first frame update
    void Start()
    {
        gameSettingsView = GameObject.FindGameObjectWithTag("GameSettingsView").transform;

        SetSoundColor();
        SetVibrateColor();
        SetViewColor();
        SetControlColor();
    }

    // Update is called once per frame
    void Update() {



    }


    private void SetVibrateColor()
    {
        ColorBlock colorBlock;
        Button settingButton;
        if (PlayerPrefs.GetInt("Vibration", 1) == 1)
        {
            settingButton = gameSettingsView.Find("SettingsItemVib").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemVib").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
        else
        {
            settingButton = gameSettingsView.Find("SettingsItemVib").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemVib").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
    }

    private void SetSoundColor()
    {
        ColorBlock colorBlock;
        Button settingButton;
        if (PlayerPrefs.GetInt("Sound", 1) == 1)
        {
            settingButton = gameSettingsView.Find("SettingsItemSound").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemSound").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
        else if (PlayerPrefs.GetInt("Sound", 1) == 0)
        {
            settingButton = gameSettingsView.Find("SettingsItemSound").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemSound").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
    }

    private void SetViewColor()
    {
        ColorBlock colorBlock;
        Button settingButton;
        if (PlayerPrefs.GetInt("View", 0) == 1)
        {
            settingButton = gameSettingsView.Find("SettingsItemView").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemView").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
        else if (PlayerPrefs.GetInt("View", 0) == 0)
        {
            settingButton = gameSettingsView.Find("SettingsItemView").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemView").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
    }

    private void SetControlColor()
    {
        ColorBlock colorBlock;
        Button settingButton;
        if (PlayerPrefs.GetInt("Control", 1) == 1)
        {
            settingButton = gameSettingsView.Find("SettingsItemControl").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemControl").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
        else if (PlayerPrefs.GetInt("Control", 1) == 0)
        {
            settingButton = gameSettingsView.Find("SettingsItemControl").Find("No").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(0, 255, 238, 255);
            colorBlock.highlightedColor = new Color32(0, 255, 238, 255);
            colorBlock.selectedColor = new Color32(0, 255, 238, 255);
            settingButton.colors = colorBlock;

            settingButton = gameSettingsView.Find("SettingsItemControl").Find("Yes").GetComponent<Button>();
            colorBlock = settingButton.colors;
            colorBlock.normalColor = new Color32(200, 204, 204, 255);
            colorBlock.highlightedColor = new Color32(200, 204, 204, 255);
            colorBlock.selectedColor = new Color32(200, 204, 204, 255);
            settingButton.colors = colorBlock;
        }
    }




    public void CloseResetPop(){
        gameSettingsView.Find("ResetPop").gameObject.SetActive(false);
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }
    public void ResetGame()
    {
        gameSettingsView.Find("ResetQuestion").gameObject.SetActive(true);
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }

    public void ResetGameY()
    {
        // delete all player prefs
        PlayerPrefs.DeleteAll();

        // delete from binary file
        SaveSystem.Reset();
        //
        PlayerPrefs.GetInt("Sound", 1);
        PlayerPrefs.GetInt("vibration", 1);
        PlayerPrefs.GetInt("View", 0);
        PlayerPrefs.GetInt("Control", 1);
        //GameObject.FindGameObjectWithTag("ResetPop").gameObject.SetActive(true);
        gameSettingsView.Find("ResetQuestion").gameObject.SetActive(false);
        gameSettingsView.Find("ResetPop").gameObject.SetActive(true);
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SetSoundColor();
        SetVibrateColor();
        SetViewColor();
        SetControlColor();
    }

    public void ResetGameN()
    {
        gameSettingsView.Find("ResetQuestion").gameObject.SetActive(false);
        FindObjectOfType<SoundManager>().Play("ButtonSound");
    }


    public void Back()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("MainMenu");
    }

    public void VibrationYes()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("Vibration", 1);
        SetVibrateColor();
    }

    public void VibrationNo()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("Vibration", 0);
        SetVibrateColor();
    }


    public void SoundYes()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("Sound", 1);
        SetSoundColor();
    }

    public void SoundNo()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("Sound", 0);
        SetSoundColor();
    }

    public void ViewFirst()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("View", 1);
        SetViewColor();
    }

    public void ViewThird()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("View", 0);
        SetViewColor();
    }

    public void ControlS()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("Control", 1);
        SetControlColor();
    }

    public void ControlB()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        PlayerPrefs.SetInt("Control", 0);
        SetControlColor();
    }

}
