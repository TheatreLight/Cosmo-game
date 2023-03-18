using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody ship;
    CapsuleCollider col1;
    BoxCollider col2;
    public GameObject ship1;
    public GameObject blood;
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tiltLR, tiltF;
    public GameObject laser;
    public GameObject lasergun;
    public float shotDelay;
    public float shotDelayMini;
    float nextShotTime = 0;
    float nextShotTime2 = 0;
    public GameObject shipExp;
    public GameObject lasergunR;
    public GameObject lasergunL;
    public GameObject laserMini;
    public GameObject laserMini2;
    int count = 5;
    

    


    // Start is called before the first frame update
    void Start()
    {
        
        ship = GetComponent<Rigidbody>();
        col1 = GetComponent<CapsuleCollider>();
        col2 = GetComponent<BoxCollider>();
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        count--;
        StartCoroutine(Blood());
        Instantiate(shipExp, ship.transform.position, Quaternion.identity);
        Destroy(other.gameObject);
        if (count == 0)
        {
            StartCoroutine(Delay());
            ControllerScript.life -= 1;
        }
        else
        {
            StopCoroutine(Delay());
        }
        if(ControllerScript.life < 0)
        {
            Destroy(gameObject);
            ControllerScript.name = "---";
        }
    }
    
   IEnumerator Delay()
    {
        InvokeRepeating("Flash", 0, 0.3f);
        col1.enabled = false;
        col2.enabled = false;
        yield return new WaitForSeconds(5);
        CancelInvoke("Flash");
        ship1.SetActive(true);
        col1.enabled = true;
        col2.enabled = true;
        count = 12;
    }

    IEnumerator Blood()
    {
        blood.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        blood.SetActive(false);
    }
    void Flash()
    {
        if (ship1.activeSelf)

            ship1.SetActive(false);
        else
            ship1.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
           

    float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");
        ship.velocity = new Vector3(MoveHorizontal, 0, MoveVertical) * speed;

        float positionX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float positionZ = Mathf.Clamp(ship.position.z, zMin, zMax);
        ship.position = new Vector3(positionX, 0, positionZ);

        ship.rotation = Quaternion.Euler(tiltF * ship.velocity.z, -180, ship.velocity.x * tiltLR);
        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {

            Instantiate(laser, lasergun.transform.position, Quaternion.identity);


            nextShotTime = Time.time + shotDelay;
            
        }
        

    if (Time.time > nextShotTime2 && Input.GetButton("Fire2"))
    {

            Instantiate(laserMini, lasergunR.transform.position, Quaternion.Euler(0, 45, 0));


            Instantiate(laserMini2, lasergunL.transform.position, Quaternion.Euler(0, -45, 0));
            nextShotTime2 = Time.time + shotDelayMini;
            
    }



        

    }
}

