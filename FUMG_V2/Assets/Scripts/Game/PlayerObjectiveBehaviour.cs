using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectiveBehaviour : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject enemyObjective;

    // Start is called before the first frame update
    void Start()
    {
        // playerObjective = GameObject.FindWithTag("PlayerObjective");
        // gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj) 
    {
        // playerObjective = Instantiate(objectToSpawn, transform.position, transform.rotation, gameObject.transform);
        // PlayerObjective po = playerObjective.GetComponent<PlayerObjective>();
        
        // Debug.Log("Target hit");
        if(obj.collider.tag == "PlayerProjectile")
        {
            // playerObjective.SetActive(true);
            // gameObject.SetActive(false);
            Debug.Log("Target hit by player");
            Destroy(obj.gameObject);
        }    
        
    }
}
