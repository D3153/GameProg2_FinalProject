using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
// using UnityEngine.SceneManagement;

public class HellbringerMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject fireball;
    
    public Transform[] patrolPoints;
    private int destination = 0;
    private NavMeshAgent agent;

    public float maxAngle = 45;
    public float maxDistance = 2;
    public float timer = 1.0f;
    public float visionCheckRate = 1.0f;

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
        agent.speed = 5f;
        if(!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint(){
        if(patrolPoints.Length == 0)
            return;

        agent.destination = patrolPoints[destination].position;

        destination = (destination + 1) % patrolPoints.Length;
    }

    void OnCollisionEnter(Collision obj)
    {
        if(obj.collider.tag == "PlayerProjectile"){
            Destroy(obj.gameObject);
            health -= 1;
        }
    }
}
