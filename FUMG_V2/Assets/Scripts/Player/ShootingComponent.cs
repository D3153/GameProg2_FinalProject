using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public GameObject objectToSpawn;
    GameObject water;
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
           
            WaterComponent wc = water.GetComponent<WaterComponent>();
            if( wc != null)
            {
                // wc.inputHoldRatio = (timer/maxHoldTime);
                water.SetActive(true);
            }
            // timer = 0.0f;
        }
        else if(Input.GetButtonUp("Fire1")){
            water.SetActive(false);
            Destroy(water);
        }
    }
}
