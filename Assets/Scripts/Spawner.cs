using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] guardianSpawnPoints;
    public Transform[] SEPSpawnPoints;

    public GameObject[] guardianPoolA;
    public GameObject[] guardianPoolB;
    public GameObject[] guardianPoolC;
    public GameObject[] newPool;

    public GameObject[] SEPs;

    GameObject obj;
    int randPoint, randPoint2;
    int zScatter;


    // Start is called before the first frame update
    void Start()
    {
        randPoint = Random.Range(0, guardianSpawnPoints.Length);
        randPoint2 = Random.Range(0, guardianSpawnPoints.Length);

        zScatter = Random.Range(0, 4);

        PickLevelToGenerateFloor();

        //Generate the SEPs if chance permits
        int SEPAppearance = Random.Range(0, 2);
        int numSEPAppearances = Random.Range(0, 3);

        if (SEPAppearance == 1)
        {
            int randSEPPack = Random.Range(0, SEPs.Length);
            int randSEPPoint = Random.Range(0, SEPSpawnPoints.Length);
            int randSEPPoint2 = Random.Range(0, SEPSpawnPoints.Length);
            int randSEPPoint3 = Random.Range(0, SEPSpawnPoints.Length);
            //minus 9.6 because we don't want it to spawn in the same z position as the spawnPoint which is where the guardians are
            //we want it to spawn at a z pos of 0 
            obj = Instantiate(SEPs[randSEPPack], SEPSpawnPoints[randSEPPoint].position, Quaternion.identity) as GameObject;
            obj.transform.SetParent(transform);


            if (numSEPAppearances == 1 && randSEPPoint2 != randSEPPoint)
            {
                int randSEPPack2 = Random.Range(0, SEPs.Length);
                //minus 9.6 because we don't want it to spawn in the same z position as the spawnPoint which is where the guardians are
                //we want it to spawn at a z pos of 0 
                obj = Instantiate(SEPs[randSEPPack2], SEPSpawnPoints[randSEPPoint2].position, Quaternion.identity) as GameObject;
                obj.transform.SetParent(transform);
            }

            if (SEPAppearance == 2 && randSEPPoint3 != randSEPPoint && randSEPPoint3 != randSEPPoint2)
            {
                int randSEPPack3 = Random.Range(0, SEPs.Length);
                //minus 9.6 because we don't want it to spawn in the same z position as the spawnPoint which is where the guardians are
                //we want it to spawn at a z pos of 0 
                obj = Instantiate(SEPs[randSEPPack3], SEPSpawnPoints[randSEPPoint3].position, Quaternion.identity) as GameObject;
                obj.transform.SetParent(transform);
            }
        }

        


    }

    void PickLevelToGenerateFloor()
    {
        if(FloorHandler.level != FloorHandler.Level.Adogen)
            NewPool();
            
        //For now, I just wanna use NewPool
        // switch (FloorHandler.level)
        // {
        //     case FloorHandler.Level.AMode:
        //         PoolA();
        //         break;
        //     case FloorHandler.Level.BMode:
        //         PoolB();
        //         break;
        //     case FloorHandler.Level.CMode:
        //         PoolC();
        //         break;
        // }
    }

    void NewPool()
    {
        bool doubleObstacleSpawn = false;
        int obstacleNum = Random.Range(0, 2);


        if(obstacleNum == 0)
            doubleObstacleSpawn = false;
        else if(obstacleNum == 1)
            doubleObstacleSpawn = true;

        if(randPoint2 == randPoint)
            doubleObstacleSpawn = false;
        
        if(randPoint2 == randPoint + 1 || randPoint2 == randPoint - 1)
            doubleObstacleSpawn = false;


        //Spawning the first obstacle
        int randObstacle = Random.Range(0, newPool.Length);

        float randScale = 0;
        if(randObstacle == 0 || randObstacle == 1 || randObstacle == 2)
            randScale = Random.Range(2.2f, 2.8f);
        else if(randObstacle == 3 || randObstacle == 4 || randObstacle == 5)
            randScale = Random.Range(55, 65);

        obj = Instantiate(newPool[randObstacle], new Vector3(guardianSpawnPoints[randPoint].position.x,
        guardianSpawnPoints[randPoint].position.y, guardianSpawnPoints[randPoint].position.z - zScatter), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(randScale, randScale, randScale);
        obj.transform.SetParent(transform);


        //Spawning the second obstacle
        if(doubleObstacleSpawn)
        {
            int randObstacle2 = Random.Range(0, newPool.Length);

            float randScale2 = 0;
            if(randObstacle2 == 0 || randObstacle2 == 1 || randObstacle2 == 2)
                randScale2 = Random.Range(2.2f, 2.8f);
            else if(randObstacle == 3 || randObstacle2 == 4 || randObstacle2 == 5)
                randScale2 = Random.Range(55, 65);

            obj = Instantiate(newPool[randObstacle2], new Vector3(guardianSpawnPoints[randPoint2].position.x,
            guardianSpawnPoints[randPoint2].position.y, guardianSpawnPoints[randPoint2].position.z - zScatter), Quaternion.identity) as GameObject;
            obj.transform.localScale = new Vector3(randScale2, randScale2, randScale2);
            obj.transform.SetParent(transform);
        }
    }

    void PoolA()
    {
        int randGuard = Random.Range(0, guardianPoolA.Length);
        float randScale = Random.Range(2.2f, 2.8f);

        obj = Instantiate(guardianPoolA[randGuard], new Vector3(guardianSpawnPoints[randPoint].position.x,
        guardianSpawnPoints[randPoint].position.y, guardianSpawnPoints[randPoint].position.z - zScatter), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(randScale, randScale, randScale);
        obj.transform.SetParent(transform);


    }

    void PoolB()
    {
        int randGuard = Random.Range(0, guardianPoolB.Length);
        float randScale = Random.Range(2.2f, 2.8f);

        obj = Instantiate(guardianPoolB[randGuard], new Vector3(guardianSpawnPoints[randPoint].position.x,
        guardianSpawnPoints[randPoint].position.y, guardianSpawnPoints[randPoint].position.z - zScatter), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(randScale, randScale, randScale);
        obj.transform.SetParent(transform);
    }

    void PoolC()
    {
        int randGuard = Random.Range(0, guardianPoolC.Length);
        float randScale = Random.Range(2.2f, 2.8f);

        obj = Instantiate(guardianPoolC[randGuard], new Vector3(guardianSpawnPoints[randPoint].position.x,
        guardianSpawnPoints[randPoint].position.y, guardianSpawnPoints[randPoint].position.z - zScatter), Quaternion.identity) as GameObject;
        obj.transform.localScale = new Vector3(randScale, randScale, randScale);
        obj.transform.SetParent(transform);
    }

}
