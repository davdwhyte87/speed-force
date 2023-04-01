﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup_SlowMo : MonoBehaviour
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
       GameObject effect = Instantiate(pickupEffect, GameObject.FindGameObjectWithTag("PowerupSpawn").transform.position
        , GameObject.FindGameObjectWithTag("PowerupSpawn").transform.rotation);
        effect.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        FindObjectOfType<SoundManager>().Play("PowerupPickupSound");
        Destroy(gameObject);
        SaveSystem.AddPowerUp("Slowmo");
        //Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
