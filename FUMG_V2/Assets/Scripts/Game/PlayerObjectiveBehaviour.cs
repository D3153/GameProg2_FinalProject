using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectiveBehaviour : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject enemyObjective;
    bool enemyObjectiveSpawned;
    float pointIncreasedPerSec = 2.0f;
    float points;

    // Start is called before the first frame update
    void Start()
    {
        enemyObjectiveSpawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        // points = pointIncreasedPerSec * Time.fixedDeltaTime;
        if(GameManager.Instance.playerPoints < 100){
            GameManager.Instance.IncreasePlayerScore();
        }
        Debug.Log(GameManager.Instance.playerPoints);
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

        if(obj.collider.tag == "PlayerProjectile")
        {
            Destroy(obj.gameObject);
        }     
    }

}
