using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript : MonoBehaviour
{
    Rigidbody enemyShip;
    public float speed;
    public GameObject asteroidExp;
    float mult;

    public GameObject laser;
    public GameObject laserGun;
    public GameObject laserGun2;
    public float shotDelay;
    float nextShotTime;

    public static Vector3 direct;

    // Start is called before the first frame update
    void Start()
    {
        mult = Random.Range(0.5f, 2);
        enemyShip = GetComponent<Rigidbody>();
        enemyShip.velocity = new Vector3(0, 0, -speed * mult);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }


        if (other.tag == "Enemy")
        {
            return;
        }

        if (other.tag == "EnemyLaser")
        {
            return;
        }

        GameObject newExplosion = Instantiate(asteroidExp, enemyShip.transform.position, Quaternion.identity);
        newExplosion.transform.localScale /= mult;


        Destroy(gameObject);
        //Destroy(other.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

        direct = enemyShip.velocity;

        if (ControllerScript.isStarted == false)
        {
            return;
        }
        if (Time.time > nextShotTime)
        {
            Instantiate(laser, laserGun.transform.position, transform.rotation);
            Instantiate(laser, laserGun2.transform.position, transform.rotation);

            nextShotTime = Time.time + shotDelay;
        }
    }
}
