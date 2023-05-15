using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectiveBehaviour : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject playerObjective;
    bool playerObjectiveSpawned;
    // Start is called before the first frame update
    void Start()
    {
        playerObjectiveSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision obj) 
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
    }
}
