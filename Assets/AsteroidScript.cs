using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    Rigidbody asteroid;
    public float rotSpeed;
    public float speed;
    public GameObject asteroidExp;
    float mult;

    // Start is called before the first frame update
    void Start()
    {
        mult = Random.Range(0.5f, 2);
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere*rotSpeed;
        asteroid.velocity = new Vector3(0, 0, -speed*mult);
        asteroid.transform.localScale /= mult;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        { return;
        }

        

        if (other.tag == "Enemy")
        {
            return;
        }

        GameObject newExplosion = Instantiate(asteroidExp, asteroid.transform.position, Quaternion.identity);
        newExplosion.transform.localScale /= mult;

        
        Destroy(gameObject);
        //Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
     
     
    }
}
