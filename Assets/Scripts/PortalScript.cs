using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    Animation portalLight;
    public Material sky3;
    Animation AdogenNotifyText;
    // Start is called before the first frame update
    void Start()
    {
        portalLight = GameObject.FindGameObjectWithTag("portalLight").GetComponent<Animation>();
        AdogenNotifyText = GameObject.Find("AdogenNotify").GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            FindObjectOfType<SoundManager>().Play("PortalSound");
            portalLight.Play();
            StartCoroutine(WaitAndNotify());
            RenderSettings.skybox = sky3;
            //Destroy(portalLight);
        }
    }

    IEnumerator WaitAndNotify(){
        yield return new WaitForSeconds(0.5f);
        AdogenNotifyText.Play();
    }
}
