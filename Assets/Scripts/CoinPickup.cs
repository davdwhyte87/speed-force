using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameObject pickupEffect;
    public GameObject disperseEffect;
    private Shop shop;

    void Awake(){
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player")
        {
            // GameObject effect = Instantiate(pickupEffect, GameObject.FindGameObjectWithTag("PowerupSpawn").transform.position, 
            // GameObject.FindGameObjectWithTag("PowerupSpawn").transform.rotation);
            // effect.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);

            //GameObject effect = Instantiate(disperseEffect, transform.position, Quaternion.identity);
            //effect.transform.SetParent(this.transform);

            //Don't do this, instead show them what they've acquired for that run only
            shop = SaveSystem.LoadShopData();
            SaveSystem.SetGems(shop.germs+= 1);

            FindObjectOfType<SoundManager>().Play("GemPickupSound");
            
            
            Destroy(gameObject);
        }
    }
}
