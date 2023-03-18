using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject enemyShip;

    public GameObject asteroid;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public float minDelay, maxDelay, minDelay2, maxDelay2;
    float nextLaunchTime = 0;
    float nextlaunchtime2 = 0;
    public GameObject[] rocks;
    GameObject currentRock;
    int index;
      
    

    // Start is called before the first frame update
    void Start()
    {
        
        

    }

    // Update is called once per frame
    void Update()
    {
                if (ControllerScript.isStarted == false)
        {
            return;
        }

        if (Time.time > nextLaunchTime)
        {
            Vector3 asteroidPosition = new Vector3(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), 0, transform.position.z);
            Instantiate(rocks[Random.Range(0, rocks.Length)], asteroidPosition, Quaternion.identity);

            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);

        }
        
        if (Time.time > nextlaunchtime2)
        {
            Vector3 enemyPosition = new Vector3(Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2), 0, transform.position.z);
            Instantiate(enemyShip, enemyPosition, Quaternion.identity);

            nextlaunchtime2 = Time.time + Random.Range(minDelay2, maxDelay2);

        }

    }
}
