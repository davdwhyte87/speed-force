using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinHandler : MonoBehaviour
{
    public Text jewwlsText;
    private Shop shop;

    void Update()
    {
        shop = SaveSystem.LoadShopData();
        jewwlsText.text = "" + shop.germs;
    }

    void Start(){
        
    }

    void Awake(){

         
    }
}
