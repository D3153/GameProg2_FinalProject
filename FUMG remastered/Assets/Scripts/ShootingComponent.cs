using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : MonoBehaviour
{
    public GameObject objectToSpawn;
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
            GameObject water = Instantiate(objectToSpawn, transform.position, transform.rotation);
            WaterCompnent wc = water.GetComponent<WaterCompnent>();
            if( wc != null)
            {
                wc.inputHoldRatio = (timer/maxHoldTime);
            }
            // timer = 0.0f;

        }
    }
}
