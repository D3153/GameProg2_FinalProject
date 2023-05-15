using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    GameObject water;
    GameObject bullet;
    float timer = 0.0f;
    public float maxHoldTime = 1.0f;

    // Update is called once per frame
    void Update()
    {

        // if (Input.GetButton("Fire1"))
        // {
        //    timer += Time.deltaTime;
        // }

        if(Input.GetButtonDown("Fire1"))
        {
            timer = 1.0f;

            water = Instantiate(objectToSpawn, transform.position, transform.rotation, gameObject.transform);
            bullet = Instantiate(objectToSpawn2, transform.position, transform.rotation, gameObject.transform);
           
            WaterComponent wc = water.GetComponent<WaterComponent>();
            BulletComponent bc = bullet.GetComponent<BulletComponent>();

            if( wc != null && bc != null)
            {
                // wc.inputHoldRatio = (timer/maxHoldTime);
                bc.inputHoldRatio = (timer/maxHoldTime);

                water.SetActive(true);
                bullet.SetActive(true);
            }
            // timer = 0.0f;
        }
        else if(Input.GetButtonUp("Fire1")){
            water.SetActive(false);
            Destroy(water);
        }
    }
}
