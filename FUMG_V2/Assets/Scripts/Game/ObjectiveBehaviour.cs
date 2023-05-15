using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveBehaviour : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject playerObjective;
    public GameObject enemyObjective;
    bool playerObjectiveSpawned;
    bool enemyObjectiveSpawned;

    // Start is called before the first frame update
    void Start()
    {
        // playerObjective = GameObject.FindWithTag("PlayerObjective");
        playerObjectiveSpawned = false;
        enemyObjectiveSpawned = false;
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
            if(playerObjectiveSpawned == false){
                Debug.Log("Target hit by player");
                // Instantiate(playerObjective, transform.position, transform.rotation, gameObject.transform);
                Instantiate(playerObjective, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(obj.gameObject);
            }
            playerObjectiveSpawned = true;
        }    
        
        if(obj.collider.tag == "EnemyProjectile")
        {
            // playerObjective.SetActive(true);
            // gameObject.SetActive(false);
            if(!enemyObjectiveSpawned){
                Debug.Log("Target hit by player");
                // Instantiate(enemyObjective, transform.position, transform.rotation, gameObject.transform);
                Instantiate(playerObjective, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(obj.gameObject); 
            }
            enemyObjectiveSpawned = true;
        }    
    }
}
