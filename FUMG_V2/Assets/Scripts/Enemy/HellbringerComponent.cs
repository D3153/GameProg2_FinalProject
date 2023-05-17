using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HellbringerComponent : MonoBehaviour
{
    public float health = 100;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void ProcessHit()
    {
        health -= 5.0f;
        healthBar.value = health;
        if(health <= 0.0f)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnCollisionEnter(Collision obj) 
    {
        if(obj.collider.tag == "PlayerProjectile")
        {
            Debug.Log("Target hit by player");
            ProcessHit();
        }    
    }
}
