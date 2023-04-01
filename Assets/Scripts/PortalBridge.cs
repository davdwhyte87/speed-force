using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBridge : MonoBehaviour
{
    public Material sky2;
    Animation bridgeNotifyText;

    // Start is called before the first frame update
    void Start()
    {
        bridgeNotifyText = GameObject.Find("BridgeNotify").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            bridgeNotifyText.Play();
            RenderSettings.skybox = sky2;
        }
    }
}
