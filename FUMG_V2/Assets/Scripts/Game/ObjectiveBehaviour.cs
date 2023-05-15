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
        playerObjectiveSpawned = false;
        enemyObjectiveSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj) 
    {
        if(obj.collider.tag == "PlayerProjectile")
        {
            if(!playerObjectiveSpawned){
                Debug.Log("Target hit by player");
                Instantiate(playerObjective, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(obj.gameObject);
            }
            playerObjectiveSpawned = true;
        }    
        
        if(obj.collider.tag == "EnemyProjectile")
        {
            if(!enemyObjectiveSpawned){
                Debug.Log("Target hit by player");
                Instantiate(enemyObjective, transform.position, transform.rotation);
                Destroy(gameObject);
                Destroy(obj.gameObject); 
            }
            enemyObjectiveSpawned = true;
        }    
    }

}
