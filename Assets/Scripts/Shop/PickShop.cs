using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickShop : MonoBehaviour
{
    //D9D9D9
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerCharacter()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("CharacterShop");
    }


    public void BackButton()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("MainMenu");
    }

    public void PowerUps()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        SceneManager.LoadScene("PowerUpShop");
    }

    public void Gems()
    {

    }
}
