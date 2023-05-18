using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HellbringerShootingBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject objective1;
    public GameObject objective2;
    public GameObject fireball;
    public NavMeshAgent agent;

    public float maxAngle = 45;
    public float maxDistance = 2;
    public float timer = 1.0f;
    public float visionCheckRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        // agent = GetComponent<NavMeshAgent>();

        // objective1 = GameObject.FindGameObjectWithTag("UncapturedObjective");
        // objective2 = GameObject.FindGameObjectWithTag("PlayerObjective");
    }

    // Update is called once per frame
    void Update()
    {
        if(SeePlayer() || SeeObjective1() || SeeObjective2())
        {
            GoToPlayer();
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer(){
        Instantiate(fireball, transform.position, transform.rotation);
    }

    public bool SeePlayer()
    {
        Vector3 vecPlayerTurret = player.transform.position - transform.position;
        if (vecPlayerTurret.magnitude > maxDistance)
        {
            return false;
        }
        Vector3 normVecPlayerTurret = Vector3.Normalize(vecPlayerTurret);
        float dotProduct = Vector3.Dot(transform.forward,normVecPlayerTurret);
        var angle = Mathf.Acos(dotProduct);
        float deg = angle * Mathf.Rad2Deg;
        if (deg < maxAngle)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position,normVecPlayerTurret);
        
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Player")
                {
                    return true;
                }
                
            }
        }
        return false;
    }

    public bool SeeObjective1()
    {
        Vector3 vecPlayerTurret = objective1.transform.position - transform.position;
        if (vecPlayerTurret.magnitude > maxDistance)
        {
            return false;
        }
        Vector3 normVecPlayerTurret = Vector3.Normalize(vecPlayerTurret);
        float dotProduct = Vector3.Dot(transform.forward,normVecPlayerTurret);
        var angle = Mathf.Acos(dotProduct);
        float deg = angle * Mathf.Rad2Deg;
        if (deg < maxAngle)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position,normVecPlayerTurret);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "UncapturedObjective" || hit.collider.tag == "PlayerObjective")
                {
                    return true;
                }

            }
        }
        return false;
    } 

    public bool SeeObjective2()
    {
        Vector3 vecPlayerTurret = objective2.transform.position - transform.position;
        if (vecPlayerTurret.magnitude > maxDistance)
        {
            return false;
        }
        Vector3 normVecPlayerTurret = Vector3.Normalize(vecPlayerTurret);
        float dotProduct = Vector3.Dot(transform.forward,normVecPlayerTurret);
        var angle = Mathf.Acos(dotProduct);
        float deg = angle * Mathf.Rad2Deg;
        if (deg < maxAngle)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position,normVecPlayerTurret);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "UncapturedObjective" || hit.collider.tag == "PlayerObjective")
                {
                    return true;
                }

            }
        }
        return false;
    } 

    void GoToPlayer(){
        agent.destination = player.transform.position;
        // if
    }

}
