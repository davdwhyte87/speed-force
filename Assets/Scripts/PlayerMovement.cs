using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    float horizontalDampening = 80f;

    public float horizontalMoveSpeed = 40f;
    public float verticalMoveSpeed = 18;
    public float runAnimSpeed;
    public Vector3 inputs = Vector3.zero;
    public static bool doMove = false;
    bool hasWon;

    public float acceleration = .6f;

    public GameObject saveMeMenu;
    public GameObject score;
    public GameObject abilityActiateButton;
    public GameObject pauseButton;
    public GameObject jewelText;
    public GameObject jewelImage;
    public Animation speedForceNotify;

    bool moveRight;
    bool moveLeft;

    private Shop shop;

    Renderer[] rend;

    Animator animator;
    SoundManager SM;

    public GameObject leftButton;
    public GameObject rightButton;

    public GameObject pickupEffect;

    public GameObject trail;



    void Awake()
    {
        shop = SaveSystem.LoadShopData();
        Physics.gravity = new Vector3(0, -30, 0);
        Time.timeScale = 1f;
        SM = SoundManager.instance;
        rb = GetComponent<Rigidbody>();
        rend = this.transform.Find("John").gameObject.GetComponentsInChildren<Renderer>();

        transform.position = new Vector3(0, 0.7f, 0);
    }


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartCoroutine("CountDown");
        doMove = false;

        //The reason this shader is being used is because setting the opacity to below 1 when phasing is only 
        //possible when the player's shader is this
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material.shader = Shader.Find("Custom/TransparentDiffuse ZWrite");
        }

        //animator.SetFloat("PlayerSpeed", 1.2f);

    }

    

    IEnumerator CountDown()
    {
        //Instead of setting it to true after a countdown, do it when the player taps play, tie this to player moving too
        //Changing the intial wait for 3 seconds to 0 seconds
        yield return new WaitForSeconds(0);
        doMove = true;
        speedForceNotify.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        runAnimSpeed = (verticalMoveSpeed / 26);
        animator.SetFloat("PlayerSpeed", runAnimSpeed);

        if (transform.position.y < 0 && doMove)
        {
            if (CameraFollow.firstPerson == true)
            {
                CameraFollow.firstPerson = false;
            }
            StartCoroutine("FallOff");
        }

       
        
        if (doMove && verticalMoveSpeed < 60)
        {
            verticalMoveSpeed += Time.deltaTime * acceleration;
        }


    }



    void FixedUpdate()
    {
        if(transform.position.z >= FloorHandler.distanceToAdogen && !hasWon) {
            doMove = false;
            hasWon = true;
            HideUI();
        }

        inputs.z = verticalMoveSpeed;

        float hInput = 0;

        if(moveLeft && !moveRight)
            hInput = -1;
        if(!moveLeft && moveRight)
            hInput = 1;

        if(Input.GetKey("a"))
            hInput= -1;
        if(Input.GetKey("d"))
            hInput = 1;

        inputs.x = Mathf.MoveTowards(inputs.x, hInput * horizontalMoveSpeed, horizontalDampening * Time.fixedDeltaTime);
        //Debug.Log(inputs.z);


        if (doMove)
        {
            rb.MovePosition(rb.position + inputs * Time.fixedDeltaTime);

            if (inputs.z != 0)
            {
                transform.forward += inputs * Time.fixedDeltaTime;
            }

            if (inputs.z == 0)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, 0), 200 * Time.fixedDeltaTime);
            }

        }

    }

    public void MoveLeft(){
        moveLeft = true;
    }
    public void StopMoveLeft(){
        moveLeft = false;
    }
    public void MoveRight(){
        moveRight = true;
    }
    public void StopMoveRight(){
        moveRight = false;
    }
        




    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            if(!PowerupHandler.isPhasing)
            {
                if (ReturnDirection(col.gameObject, this.gameObject) == HitDirection.Top)
                {
                    if (CameraFollow.firstPerson == true)
                    {
                        CameraFollow.firstPerson = false;
                    }

                    StartCoroutine("HitObstacle");
                    FindObjectOfType<SoundManager>().Play("HitObstacle");
                   
                    col.collider.enabled = false;

                }
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Guardian")
        {
            if(!PowerupHandler.isPhasing)
            {
                if (CameraFollow.firstPerson == true)
                {
                    CameraFollow.firstPerson = false;
                }

                if (transform.position.z > col.transform.position.z - 1 && transform.position.z < col.transform.position.z + 1)
                {
                    transform.LookAt(col.transform);
                    StartCoroutine("HitGuardian");
                }
                else
                {
                    transform.LookAt(col.transform);
                    if (col.transform.position.z > transform.position.z)
                    {
                        transform.position = col.transform.position - new Vector3(0, 0, 1.2f);
                    }
                    else
                    {
                        transform.position = col.transform.position + new Vector3(0, 0, 1.2f);
                    }

                    StartCoroutine("HitGuardian");
                }

            }

        }

        if(col.tag == "Coin")
        {
            GameObject effect = Instantiate(pickupEffect, GameObject.Find("PowerupSpawnSpot").transform.position, Quaternion.identity);
            effect.transform.SetParent(GameObject.Find("PowerupSpawnSpot").transform);

        }


    }







    private enum HitDirection { None, Top, Bottom, Forward, Back, Left, Right }

    private HitDirection ReturnDirection(GameObject Object, GameObject ObjectHit)
    {

        HitDirection hitDirection = HitDirection.None;
        RaycastHit MyRayHit;
        Vector3 direction = (Object.transform.position - ObjectHit.transform.position).normalized;
        Ray MyRay = new Ray(ObjectHit.transform.position, direction);

        if (Physics.Raycast(MyRay, out MyRayHit))
        {

            if (MyRayHit.collider != null)
            {

                Vector3 MyNormal = MyRayHit.normal;
                MyNormal = MyRayHit.transform.TransformDirection(MyNormal);

                if (MyNormal == MyRayHit.transform.up) { hitDirection = HitDirection.Top; }
                if (MyNormal == -MyRayHit.transform.up) { hitDirection = HitDirection.Bottom; }
                if (MyNormal == MyRayHit.transform.forward) { hitDirection = HitDirection.Forward; }
                if (MyNormal == -MyRayHit.transform.forward) { hitDirection = HitDirection.Back; }
                if (MyNormal == MyRayHit.transform.right) { hitDirection = HitDirection.Right; }
                if (MyNormal == -MyRayHit.transform.right) { hitDirection = HitDirection.Left; }
            }
        }
        return hitDirection;
    }



    IEnumerator HitObstacle()
    {
        Time.timeScale = 1f;
        animator.SetBool("IsDead", true);
        doMove = false;

        yield return new WaitForSeconds(1);
        HideUI();
    }

    IEnumerator HitGuardian()
    {
        Time.timeScale = 1f;
        doMove = false;
        animator.SetBool("IsAlmostDead", true);
        yield return new WaitForSeconds(.15f);
        animator.SetBool("IsAlmostDead", false);
        animator.SetBool("IsDead", true);
        FindObjectOfType<SoundManager>().Play("HitGuardian");
        yield return new WaitForSeconds(1);
        HideUI();
    }

    IEnumerator FallOff()
    {
        Time.timeScale = 1f;
        FindObjectOfType<SoundManager>().Play("FallOfSound");
        trail.SetActive(false);
        animator.SetBool("IsFalling", true);
        doMove = false;
        yield return new WaitForSeconds(1);
        HideUI();
    }

    void HideUI()
    {
        if (!hasWon)
            saveMeMenu.SetActive(true);
            
        abilityActiateButton.SetActive(false);
        pauseButton.SetActive(false);
        score.SetActive(false);
        jewelText.SetActive(false);
        jewelImage.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);

        if(speedForceNotify.isPlaying)
            speedForceNotify.gameObject.SetActive(false);
        
    
    }

   

}
