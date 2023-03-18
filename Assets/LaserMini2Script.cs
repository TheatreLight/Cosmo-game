using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMini2Script : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            ControllerScript.score += 10;
        }

        else if (other.tag == "Enemy")
        { 
            ControllerScript.score += 30;
        }

        else
        { 
            return; 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
