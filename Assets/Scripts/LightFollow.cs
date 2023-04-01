using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour
{
    public Transform player;
    
    public static bool firstPerson = false;
    float playerHeight;
    float playerRotation;

    Light cam;


    // Start is called before the first frame update
    void Start()
    {

        cam = gameObject.GetComponent<Light>();

        if(PlayerPrefs.GetInt("View", 0) == 1){
            firstPerson = true;
        }
        else if(PlayerPrefs.GetInt("View", 0) == 0){
            firstPerson = false;
        }



        playerHeight = 2.8f;
        playerRotation = 4f;
        // cam.nearClipPlane = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if(firstPerson == false){
            transform.position = new Vector3(player.position.x, player.position.y + 4.5f, player.position.z - 5);
            //transform.rotation = Quaternion.Euler(0, 26, 0);
        }
        else{
            transform.position = new Vector3(player.position.x, player.position.y + playerHeight, player.position.z  - .4f);
            transform.rotation = Quaternion.Euler(player.rotation.x + playerRotation, player.rotation.y, player.rotation.z);;
        }
        
    }
}
