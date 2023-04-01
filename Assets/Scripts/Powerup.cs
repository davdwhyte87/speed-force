using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public GameObject[] powerUps;
    private Vector3 position;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject gamePowerup;
        position = new Vector3(Random.Range(transform.position.x -3f, transform.position.x + 3f), 2, Random.Range(transform.position.z -10f, transform.position.z + 10f));
        gamePowerup = Instantiate(powerUps[Random.Range(0, powerUps.Length)], position, Quaternion.identity)as GameObject;
        gamePowerup.transform.SetParent(transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
