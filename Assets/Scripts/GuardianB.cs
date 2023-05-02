using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardianB : MonoBehaviour
{
    Transform player;
    Animator animator;

    public bool isDead;
    public bool isMoving;
    //bool hasStartedSlap = false;



    private Vector3 position;
    public float dir;
    public int maxZoom;
    public float horizontalDampening;
    public float distanceToPlayer;
    public float playerInSightFigure;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        dir = 0;
        maxZoom = 7;
        //transform.position = new Vector3(Random.Range(-3, 3),  transform.position.y, transform.position.z);

        animator.SetFloat("MoveDirection", dir);
        animator.SetBool("IsMoving", isMoving);
    }

    // Update is called once per frame
    void Update()
    {

        // if(!isDead && !PowerupHandler.isPhasing && PlayerMovement.doMove){
        //     transform.LookAt(player);
        // }

        // float dist = Vector3.Distance(player.position, transform.position);

        // if(dist < 3f && hasStartedSlap == false && !PowerupHandler.isPhasing){
        //     //StartCoroutine(Strike());

        // }
        
        transform.LookAt(player);

        distanceToPlayer = Mathf.Abs(transform.position.z - player.position.z);

        if (PlayerMovement.doMove)
        {

            if (transform.position.z > player.position.z)
            {
                if (distanceToPlayer < playerInSightFigure)
                {
                    

                    if (transform.position.x != player.position.x)
                    {
                        isMoving = true;
                        if (transform.position.x > player.position.x)
                            dir = 1;
                        else if (transform.position.x < player.position.x)
                            dir = -1;
                    }
                    else if (transform.position.x == player.position.x)
                    {
                        dir = 0;
                        isMoving = false;
                    }



                    // if (gameObject.tag.Equals("FastBox"))
                    // {
                    //     maxZoom = 30;
                    // }

                    position.x = Mathf.MoveTowards(position.x, player.position.x, horizontalDampening * Time.deltaTime);
                    animator.SetFloat("MoveDirection", dir);
                    animator.SetBool("IsMoving", isMoving);

                    transform.position = position;

                }
                else
                {
                    dir = 0;
                    isMoving = false;

                    animator.SetFloat("MoveDirection", dir);
                    animator.SetBool("IsMoving", isMoving);
                }

            }
            else
            {
                dir = 0;
                isMoving = false;

                animator.SetFloat("MoveDirection", dir);
                animator.SetBool("IsMoving", isMoving);



            }

        }
        else
        {
            dir = 0;
            isMoving = false;

            animator.SetFloat("MoveDirection", dir);
            animator.SetBool("IsMoving", isMoving);



        }

    }

    void OnTriggerEnter(Collider col)
    {

        if (col.tag == "Player")
        {
            if (PowerupHandler.isPhasing)
            {
                gameObject.GetComponent<Collider>().enabled = false;
            }
            else
            {

            }

        }
    }

    // IEnumerator Strike(){
    //     hasStartedSlap = true;
    //     //Time.timeScale = .4f;
    //     animator.SetBool("PlayerTouched", true);
    //     yield return new WaitForSeconds(1);
    //     animator.SetBool("PlayerTouched", false);
    // }
}
