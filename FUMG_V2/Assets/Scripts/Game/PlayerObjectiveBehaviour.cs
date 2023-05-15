using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectiveBehaviour : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject enemyObjective;
    bool enemyObjectiveSpawned;

    // Start is called before the first frame update
    void Start()
    {
        enemyObjectiveSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision obj) 
    {
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
