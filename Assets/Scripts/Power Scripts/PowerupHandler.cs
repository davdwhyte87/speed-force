using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupHandler : MonoBehaviour
{
    public static bool isBlasting = false;
    public static bool isPhasing = false;
    public static bool isTurtleTime = false;
    public static bool canUseAbility;


    public Text abilityCountText;
    public Text pauseTurtleTimeCountText;
    public Text pausePhasingCountText;
    public Text pauseEnergyBlastCountText;

    public static int slowMoCount;
    public static int phasingCount;
    public static int sonicBlastCount;
    public static int gemMagnetCount;

    public GameObject blastSpark;
    public GameObject boxSpark;

    public Transform player;
    public Transform playerCoinMagnetSpot;

    public static bool hasClickedMenu = false;

    float timer = 15;

    public GameObject abilityActivateButton;
    public static Ability currentAbility;

    Renderer[] rend;
    Text abilityText;


    void Awake()
    {
        //PhasingText.text = "Phasing: " + phasingCount;
        rend = player.Find("John").gameObject.GetComponentsInChildren<Renderer>();

        //Each time player runs, make a random ability be the default
        //Well to truly make it eah run,, you gotta put the  code in a func and call the func when you rest game on retry 
        int randAbility = Random.Range(0, 3);
        switch (randAbility)
        {
            case 0:
                currentAbility = Ability.TurtleTime;
                break;
            case 1:
                currentAbility = Ability.Phasing;
                break;
            case 2:
                currentAbility = Ability.EnergyBlast;
                break;
        }

        FetchAbilitiesCount();
        
    }

     void Start()
    {
        //No need to call these on start here because they're already called in the SetPauseCurrentAbilityUI func in the PauseScript
        //which is called on start
        //SetActivateAbilityButton();
        //SetAbilityCountUI();
    }

    //Call this only awake and on retry game 
    void FetchAbilitiesCount()
    {
        //Basically we wanna take only 3 of each ability into the game
        if(SaveSystem.CountSlowmo() > 3)
            slowMoCount = 3;
        else
            slowMoCount = SaveSystem.CountSlowmo();
        
        if(SaveSystem.CountPhasing() > 3)
            phasingCount = 3;
        else
            phasingCount = SaveSystem.CountPhasing();

        if(SaveSystem.CountBlast() > 3)
            sonicBlastCount = 3;
        else
            sonicBlastCount = SaveSystem.CountBlast();
    }

    //Call this one when you use an ability only
    void UpdateAbilityCount()
    {
        if(currentAbility == Ability.TurtleTime)
            slowMoCount--;
        else if(currentAbility == Ability.Phasing)
            phasingCount--;
        else if(currentAbility == Ability.EnergyBlast)
            sonicBlastCount--;
    }   

    public void SetActivateAbilityButton()
    {
        //Make this a global variable and initialize it on start? Yeah
        

        if (currentAbility == Ability.TurtleTime)
        {
            abilityText = abilityActivateButton.GetComponentInChildren<Text>();
            abilityText.color = Color.green;
            abilityText.text = "Turtle time";

            abilityCountText.color = Color.green;
 
        }
        else if (currentAbility == Ability.Phasing)
        {
            abilityText = abilityActivateButton.GetComponentInChildren<Text>();
            abilityText.color = Color.yellow;
            abilityText.text = "Phasing";

            abilityCountText.color = Color.yellow;
        }
        else if (currentAbility == Ability.EnergyBlast)
        {
            abilityText = abilityActivateButton.GetComponentInChildren<Text>();
            abilityText.color = Color.red;
            abilityText.text = "Energy blast";

            abilityCountText.color = Color.red;
        }
    }

    public void CheckIfExhaustedAbility()
    {
        abilityActivateButton.GetComponent<Button>().interactable = true;
        canUseAbility = true;

        if(currentAbility == Ability.TurtleTime && slowMoCount < 1)
            DisableAbilityActivateButton();
        if(currentAbility == Ability.Phasing && phasingCount < 1)
            DisableAbilityActivateButton();
        if(currentAbility == Ability.EnergyBlast && sonicBlastCount < 1)
            DisableAbilityActivateButton();

    } 


    public void DisableAbilityActivateButton(){
        abilityActivateButton.GetComponent<Button>().interactable = false;
        canUseAbility = false;

    }

    public void SetAbilityCountUI()
    {
        if (currentAbility == Ability.TurtleTime)
        {
            abilityCountText.text = "" + slowMoCount;

        }
        else if (currentAbility == Ability.Phasing)
        {
            abilityCountText.text = "" + phasingCount;
        }
        else if (currentAbility == Ability.EnergyBlast)
        {
            abilityCountText.text = "" + sonicBlastCount;
        }

        CheckIfExhaustedAbility();


        //Set the abilty counts in the pause menu UI too
        pauseTurtleTimeCountText.text = "" + slowMoCount;
        pausePhasingCountText.text = "" + phasingCount;
        pauseEnergyBlastCountText.text = "" + sonicBlastCount;
    }

   

    public enum Ability
    {
        TurtleTime,
        Phasing,
        EnergyBlast
    }

    public void ActivateAbility()
    {
        switch (currentAbility)
        {
            case Ability.TurtleTime:
                if(slowMoCount > 0)
                    TurtleTime();
                break;
            case Ability.Phasing:
                if(phasingCount > 0)
                    Phasing();
                break;
            case Ability.EnergyBlast:
                if(sonicBlastCount > 0)
                    EnergyBlast();
                break;
        }

        //Should this be after confirming that the ability was actually activated
        //because if there's no deduction then there's no point in calling this
        SetAbilityCountUI();
    }


    void TurtleTime()
    {
        if (Time.timeScale == 1)
        {
            //Fix in a new sound play
            //FindObjectOfType<SoundManager>().Play("SlowMoSound");
            SaveSystem.RemovePowerUp("Slowmo");
            UpdateAbilityCount();
            StartCoroutine(SlowMoCall());
        }
    }
    IEnumerator SlowMoCall()
    {
        isTurtleTime = true;
        Time.timeScale = .5f;
        
        yield return new WaitForSeconds(3f);

        isTurtleTime = false;
    }

    void Phasing()
    {
        if (!isPhasing)
            {
                
                SaveSystem.RemovePowerUp("Phase");
                UpdateAbilityCount();
                //iTween.ShakePosition(gameObject, new Vector3(.1f, 0, 0), .2f);
                StartCoroutine(Phase());
                FindObjectOfType<SoundManager>().Play("PhasingSound");
            }
    }
    IEnumerator Phase()
    {
        isPhasing = true;
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material.SetVector("_Color", new Vector4(1, 1, 1, .3f));
        }

        yield return new WaitForSeconds(3f);

        isPhasing = false;
        for (int i = 0; i < rend.Length; i++)
        {
            rend[i].material.SetVector("_Color", new Vector4(1, 1, 1, 1));
        }
    }

    void EnergyBlast()
    {
        if (!isBlasting)
        {
            isBlasting = true;
            FindObjectOfType<SoundManager>().Play("VapourizeSound");
            StartCoroutine(BlastCall());
        }
    }
    IEnumerator BlastCall()
    {
        SaveSystem.RemovePowerUp("Blast");
        UpdateAbilityCount();
        GameObject effect = Instantiate(blastSpark, GameObject.FindGameObjectWithTag("PowerupSpawn").transform.position
        , GameObject.FindGameObjectWithTag("PowerupSpawn").transform.rotation);
        effect.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);

        GameObject[] objs2 = GameObject.FindGameObjectsWithTag("Guardian");
        for (int i = 0; i < objs2.Length; i++)
        {
            if (objs2[i].transform.position.z > player.position.z && objs2[i].transform.position.z < player.position.z + 60)
            {
                objs2[i].GetComponent<Animator>().SetBool("IsDie", true);
                objs2[i].GetComponent<Collider>().enabled = false;
                objs2[i].GetComponent<GuardianBehave>().isDead = true;
                Destroy(objs2[i], 2);
            }
        }

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].transform.position.z > player.position.z && objs[i].transform.position.z < player.position.z + 50)
            {
                Instantiate(boxSpark, objs[i].transform.position, objs[i].transform.rotation);
                Destroy(objs[i]);
            }
        }

        //No need to add 2 second delay before you can use the ability again
        //yield return new WaitForSeconds(5f);
        yield return null;

        isBlasting = false;
    }





    void Update()
    {


        //Sample checking wether to display it or not
        //This shit should be removed, but before that, investigate hasClickedMenu
        // if (phasingCount > 0 && Time.timeScale > 0 && PlayerMovement.doMove && hasClickedMenu == false)
        // {
        //     phasingFullButton.SetActive(true);
        //     PhasingText.text = "" + phasingCount;

        // }
        // else
        // {
        //     phasingFullButton.SetActive(false);
        //     PhasingText.text = "";
        // }



        //Logic that allows slow mo to work
        if (Time.timeScale > 0 && Time.timeScale < 1 && !isTurtleTime)
        {
            Time.timeScale += .1f * Time.unscaledDeltaTime;
            //I feel the next line is unecessary due to the conditions but lets see
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }





        //Don't enable the magnetize powerup. We dont want it in the game
        //Magnetize();

    }

 







    void Magnetize()
    {
        if (PlayerMovement.doMove && gemMagnetCount > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
            SaveSystem.RemovePowerUp("Magnet");
            timer = 15f;
        }

        if (gemMagnetCount > 0)
        {
            GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
            for (int i = 0; i < coins.Length; i++)
            {
                if (coins[i].transform.position.z > player.position.z && coins[i].transform.position.z < player.position.z + 10)
                {
                    //coins[i].transform.MoveTowards(player.position * Time.deltaTime * 1);
                    /* Look at Player*/
                    //coins[i].transform.rotation = Quaternion.Slerp (coins[i].transform.rotation
                    //, Quaternion.LookRotation ((player.position - new Vector3(0, 1, 0)) - coins[i].transform.position)
                    //, 500 * Time.deltaTime);

                    coins[i].transform.LookAt(playerCoinMagnetSpot);

                    /* Move at Player*/
                    coins[i].transform.position += coins[i].transform.forward * 70 * Time.deltaTime;
                }
            }
        }

    }


}
