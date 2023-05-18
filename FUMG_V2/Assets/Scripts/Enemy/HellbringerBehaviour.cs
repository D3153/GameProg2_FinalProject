using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using UnityEngine.SceneManagement;

public class HellbringerBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject fireball;
    
    public Transform[] patrolPoints1;
    public Transform[] patrolPoints2;
    public Transform[] patrolPoints3;

    private int destination = 0;
    private NavMeshAgent agent;

    public float maxAngle = 45;
    public float maxDistance = 2;
    public float timer = 1.0f;
    public float visionCheckRate = 1.0f;
    public float speed = 5f;

    public float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.autoBraking = false;

        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
        // if(SeePlayer())
        // {
        //     Debug.Log("Follow Player");
        //     GoToPlayer();
        // }
    }

    void GotoNextPoint(){
        if(GameManager.Instance.spawnPoint.name == "ObjectiveSpawnPoint1"){
            if(patrolPoints1.Length == 0)
                return;

            agent.destination = patrolPoints1[destination].position;

            destination = (destination + 1) % patrolPoints1.Length;
        }
        
        if(GameManager.Instance.spawnPoint.name == "ObjectiveSpawnPoint2"){
            if(patrolPoints2.Length == 0)
                return;

            agent.destination = patrolPoints2[destination].position;

            destination = (destination + 1) % patrolPoints2.Length;
        }

        if(GameManager.Instance.spawnPoint.name == "ObjectiveSpawnPoint3"){
            if(patrolPoints3.Length == 0)
                return;

            agent.destination = patrolPoints3[destination].position;

            destination = (destination + 1) % patrolPoints3.Length;
        }
    }

    void ShootAtPlayer(){
        Instantiate(fireball, transform.position, transform.rotation);
    }

    // public bool SeePlayer()
    // {
    //     Vector3 vecPlayerTurret = player.transform.position - transform.position;
    //     if (vecPlayerTurret.magnitude > maxDistance)
    //     {
    //         return false;
    //     }
    //     Vector3 normVecPlayerTurret = Vector3.Normalize(vecPlayerTurret);
    //     float dotProduct = Vector3.Dot(transform.forward,normVecPlayerTurret);
    //     var angle = Mathf.Acos(dotProduct);
    //     float deg = angle * Mathf.Rad2Deg;
    //     if (deg < maxAngle)
    //     {
    //         RaycastHit hit;
    //         Ray ray = new Ray(transform.position,normVecPlayerTurret);
        
    //         if (Physics.Raycast(ray, out hit))
    //         {
    //             if (hit.collider.tag == "Player")
    //             {
    //                 return true;
    //             }
                
    //         }
    //     }
    //     return false;
    // }

    // void GoToPlayer(){
    //     agent.destination = player.transform.position;
    //     // if
    // }

    // void OnCollisionEnter(Collision obj)
    // {
    //     if(obj.collider.tag == "PlayerProjectile"){
    //         Destroy(obj.gameObject);
    //         health -= 1;
    //     }
    // }
}
