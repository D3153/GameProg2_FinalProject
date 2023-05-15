using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using UnityEngine.SceneManagement;

public class HellbringerBehaviour : MonoBehaviour
{
    public GameObject player;
    
    public Transform[] patrolPoints;
    private int destination = 0;
    private NavMeshAgent agent;

    public float maxAngle = 45;
    public float maxDistance = 2;
    public float timer = 1.0f;
    public float visionCheckRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
         agent = GetComponent<NavMeshAgent>();

        // player = GameObject.FindGameObjectWithTag("Player");

        agent.autoBraking = false;

        GotoNextPoint();
    }

    // Update is called once per frame
    void Update()
    {
        // if(SeePlayer())
        // {
        //     // Go to Player
        //     agent.speed = 4.5f;
        //     GotoPlayer();
        // }
        // else {
            // Patrol
            agent.speed = 2f;
            if(!agent.pathPending && agent.remainingDistance < 0.5f)
                GotoNextPoint();
        // }
    }

    void GotoNextPoint(){
        if(patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[destination].position;

        destination = (destination + 1) % patrolPoints.Length;
    }

    void GotoPlayer(){
        agent.destination = player.transform.position;
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

    // void OnCollisionEnter(Collision who)
    // {
    //     if(who.gameObject.tag == "Player"){
    //         SceneManager.LoadScene(0);
    //     }
    // }
}
