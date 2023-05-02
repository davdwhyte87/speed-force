using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorHandler : MonoBehaviour
{
    public GameObject theFloor;


    List<GameObject> activeTiles;
    public Vector3 currentSpawnPos;
    public static Level level;

    GameObject floor;

    public Transform playerPos;

    //Variable  used to know when to generate new floor
    public float tileLength = 150;
    public int numberOfFloors;

    public GameObject adogenPortal;
    bool stopSpawning;
    [SerializeField] int numStartFloors;
    [SerializeField] int numEndFloors;
    [SerializeField] int numFloorA, numFloorB, numFloorC;
    [SerializeField] int sizeOfEachFloor;

    //variable used to calculate the distance to Adogen
    public static float distanceToAdogen;




    public enum Level
    {
        AMode,
        BMode,
        CMode,
        Adogen
    }


    void Start()
    {
        level = Level.AMode;

        //numfloorE is the number of floors at which point the player reaches Adogen Mode and guardians stop spawning
        //minus 0.5 because distance to Adogen is half a floor less due to portal spawning at middle of the last floor not at end
        distanceToAdogen = (numStartFloors + numFloorC + numEndFloors - 0.5f) * sizeOfEachFloor;

    }


    void Awake()
    {
        //Already taken care of in inspector
        //currentSpawnPos = new Vector3(0, 0, 240);
        activeTiles = new List<GameObject>();
    }


    void Update()
    {
        SetLevel();
        
        //Do we even need to check if player can move? Yes, what about when the user hasn't tapped play
        if (PlayerMovement.doMove)
        {
            if (playerPos.position.z > (tileLength - 100) && level != Level.Adogen)
            {
                    SpawnFloor();

                    //It's necessary for it to be 8 because you used 140 over there
                    if (numberOfFloors > 8)
                        Delete();

                    tileLength += sizeOfEachFloor;


            }
            else if(level == Level.Adogen && !stopSpawning)
            {
                //When you edit anything here, remember to reflect in in the fields of this gameobject
                SpawnFloor();SpawnFloor();SpawnFloor();SpawnFloor();SpawnFloor();
                SpawnFloor();SpawnFloor();SpawnFloor();SpawnFloor();SpawnFloor();

                Instantiate(adogenPortal, currentSpawnPos - new Vector3(0, 8, 10), Quaternion.identity);

                SpawnFloor();SpawnFloor();
                stopSpawning = true;
            }
        }

        //RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);


        // if (level == Level.level1 || level == Level.level2)
        // {
        //     RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);
        // }

    }





    void Delete()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void SetLevel()
    {
        if (numberOfFloors < numFloorA)
        {
            level = Level.AMode;


        }
        else if (numberOfFloors >= numFloorA && numberOfFloors < numFloorB)
        {
            level = Level.BMode;
            //RenderSettings.skybox = sky2;

            //PlayerMovement.verticalMoveSpeed = 23;
            //BridgeNotify();
        }
        else if (numberOfFloors >= numFloorB && numberOfFloors < numFloorC)
        {
            level = Level.CMode;
            //RenderSettings.skybox = sky3;
            //PlayerMovement.verticalMoveSpeed = 26;
            //SpeedForceNotify();
        }
        else if (numberOfFloors >= numFloorC)
        {
            level = Level.Adogen;
            //RenderSettings.skybox = sky3;
            //PlayerMovement.verticalMoveSpeed = 26;
            //SpeedForceNotify();
        }
    }

    void SpawnFloor()
    {
        //int number = Random.Range(0, floors1.Length);
        floor = Instantiate(theFloor, currentSpawnPos, Quaternion.identity) as GameObject;
        activeTiles.Add(floor);
        currentSpawnPos += new Vector3(0, 0, sizeOfEachFloor);
        numberOfFloors++;

    }

}
