using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_GemMagnet : MonoBehaviour
{
    public GameObject pickupEffect;

    void OnTriggerEnter(Collider col){
        if(col.CompareTag("Player")){
            PickUp();
        }
    }

    void PickUp(){
        if(FindObjectOfType<SoundManager>().isVibrating){
            Handheld.Vibrate();
        }
        
        SaveSystem.AddPowerUp("Magnet");
        GameObject effect = Instantiate(pickupEffect, GameObject.FindGameObjectWithTag("PowerupSpawn").transform.position
        , GameObject.FindGameObjectWithTag("PowerupSpawn").transform.rotation);
        effect.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        FindObjectOfType<SoundManager>().Play("PowerupPickupSound");
        Destroy(gameObject);
    }
}
