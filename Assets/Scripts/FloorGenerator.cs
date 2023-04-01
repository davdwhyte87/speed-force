using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] floors1;
    public GameObject[] floors2;
    public GameObject[] floors3;
    public GameObject startingFloor;

    public GameObject firstSpeedForceBridgeFloor;
    
    List<GameObject> activeTiles;
    public Vector3 currentSpawnPos;
    public static Level level;
    GameObject floor;
    public Transform playerPos;
    public float tileLength = 150;
    public int numberOfFloors;
    

    public Animation earthNotifyText;

    public GameObject porthole;
    public GameObject bridgeNotify;

    bool hasEnteredPortHole = false;
    bool hasEnteredBridgeNotify = false;
    bool hasEnteredEarthNotify = false;

    public GameObject fisrtSpeedForceFloor;


    public enum Level{
        level1,
        level2,
        level3
    }


    void Start()
    {
        level = Level.level1;
        GenerateFirstFloor();
        GenerateFirstFloor();
        GenerateFirstFloor();
        GenerateFloor1();
        GenerateFloor1();
        GenerateFloor1();
        GenerateFloor1();

    }


    void Awake(){
        currentSpawnPos = new Vector3(26, 0, 0);
        activeTiles = new List<GameObject>();
    }


    void Update()
    {
        SetLevel();
        if(PlayerMovement.doMove){
            if(playerPos.position.x > tileLength - 40){
                PickLevelToGenerateFloor();
                Delete();
                tileLength += 30;
            } 
        }

        if(level == Level.level1 || level == Level.level2){
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.5f);
        }
    }


    void PickLevelToGenerateFloor(){
        if(level == Level.level1){
            GenerateFloor1();
        }
        else if(level == Level.level2){
            GenerateFloor2();
        }
        else if(level == Level.level3){
            GenerateFloor3();
        }
    }


    void Delete(){
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void SetLevel(){
        if(numberOfFloors < 20){
            level = Level.level1;
            //PlayerMovement.verticalMoveSpeed = 18;
            if(hasEnteredEarthNotify == false){
                earthNotifyText.Play();
                hasEnteredEarthNotify = true;
            }
            
        }
        else if(numberOfFloors >= 20 && numberOfFloors < 30){
            level = Level.level2;
            //RenderSettings.skybox = sky2;
            
            //PlayerMovement.verticalMoveSpeed = 23;
            //BridgeNotify();
        }
        else if(numberOfFloors >= 30){
            level = Level.level3;
            //RenderSettings.skybox = sky3;
            //PlayerMovement.verticalMoveSpeed = 26;
            //SpeedForceNotify();
        }
    }

    void GenerateFloor1(){
        int number = Random.Range(0, floors1.Length);
        floor =  Instantiate(floors1[number], currentSpawnPos, Quaternion.identity) as GameObject;
        activeTiles.Add(floor);
        currentSpawnPos += new Vector3(30, 0, 0);
        numberOfFloors++;
        
    }

    void GenerateFloor2(){
        if(hasEnteredBridgeNotify == false){
            Instantiate(bridgeNotify, currentSpawnPos - new Vector3(17, 0, 0), Quaternion.Euler(90, 90, 0));
            hasEnteredBridgeNotify = true;
        }
        else{
            int number = Random.Range(0, floors2.Length);
            floor =  Instantiate(floors2[number], currentSpawnPos, Quaternion.identity) as GameObject;
            activeTiles.Add(floor);
            currentSpawnPos += new Vector3(30, 0, 0);
            numberOfFloors++;
        }
        
    }

    void GenerateFirstFloor(){

        floor =  Instantiate(startingFloor, currentSpawnPos, Quaternion.identity) as GameObject;
        activeTiles.Add(floor);
        currentSpawnPos += new Vector3(30, 0, 0);
        numberOfFloors++;
    }

    void GenerateFirstSpeedForceFloor(){
        floor =  Instantiate(fisrtSpeedForceFloor, currentSpawnPos, Quaternion.identity) as GameObject;
        activeTiles.Add(floor);
        currentSpawnPos += new Vector3(30, 0, 0);
        numberOfFloors++;
    }

    void GenerateFloor3(){
        if(hasEnteredPortHole == false){
            Instantiate(porthole, currentSpawnPos - new Vector3(-13, 7, 0), Quaternion.Euler(0, 90, 0));
            floor =  Instantiate(firstSpeedForceBridgeFloor, currentSpawnPos, Quaternion.identity) as GameObject;
            activeTiles.Add(floor);
            currentSpawnPos += new Vector3(30, 0, 0);
            numberOfFloors++;
            GenerateFirstSpeedForceFloor();
            GenerateFirstSpeedForceFloor();
            hasEnteredPortHole = true;
        }
        else
        {
            int number = Random.Range(0, floors3.Length);
            floor =  Instantiate(floors3[number], currentSpawnPos, Quaternion.identity) as GameObject;
            activeTiles.Add(floor);
            currentSpawnPos += new Vector3(30, 0, 0);
            numberOfFloors++;
        }
        
    }

}
