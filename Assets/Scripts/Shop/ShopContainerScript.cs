using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopContainerScript : MonoBehaviour
{
    private Transform ShopContainer;

    // Start is called before the first frame update
    void Start()
    {
        ShopContainer = GameObject.FindGameObjectWithTag("ShopContainer").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CloseNotEngoughGemsPop()
    {
        // play sound
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        // open popup
        ShopContainer.Find("PurchaseNoGemsPop").gameObject.SetActive(false);
    }

    public void CloseAlreadyPurchasedPop()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        ShopContainer.Find("PurchaseBadPop").gameObject.SetActive(false);
    }

    public void ClosePlayerEquipPop()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        ShopContainer.Find("EquipOkPop").gameObject.SetActive(false);
    }

    public void Back()
    {
        FindObjectOfType<SoundManager>().Play("ButtonSound");
        ShopContainer.Find("PurchaseOKPop").gameObject.SetActive(false);
    }
}
