using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    private Rigidbody rb;
    public float strenght = 10.0f;
    public float inputHoldRatio = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(transform.forward * strenght * inputHoldRatio, ForceMode.Impulse);
        }
        Destroy(gameObject,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj) 
    {
        if(obj.collider.tag == "UncapturedObjective")
        {
            Destroy(gameObject);
        }    
    }
}
