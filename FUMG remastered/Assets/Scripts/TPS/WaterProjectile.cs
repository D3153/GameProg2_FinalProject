using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    private Rigidbody waterRigidbody;
    
    private void Awake() {
     waterRigidbody = GetComponent<Rigidbody>();    
    }
    private void Start() {
        float speed = 10f;
        waterRigidbody.velocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(gameObject);    
    }

}
