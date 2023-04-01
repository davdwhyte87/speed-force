using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianBehave : MonoBehaviour
{
    Transform player;
    Animator animator;
    public bool isDead;
    bool hasStartedSlap = false;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!isDead && !PowerupHandler.isPhasing){
            transform.LookAt(player);
        }

        float dist = Vector3.Distance(player.position, transform.position);

        if(dist < 3f && hasStartedSlap == false && !PowerupHandler.isPhasing){
            StartCoroutine(Strike());
            
        }
        
        
    }

    void OnTriggerEnter(Collider col){

        if(col.tag == "Player"){
            if(PowerupHandler.isPhasing)
            {
                gameObject.GetComponent<Collider>().enabled = false;
            }
            else{
                
            }
            
        }
    }

    IEnumerator Strike(){
        hasStartedSlap = true;
        //Time.timeScale = .4f;
        animator.SetBool("PlayerTouched", true);
        yield return new WaitForSeconds(1);
        animator.SetBool("PlayerTouched", false);
    }
}
