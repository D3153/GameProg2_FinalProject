using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HellbringerShootingBehaviour : MonoBehaviour
{
    public GameObject player;
    public GameObject fireball;

    public float maxAngle = 45;
    public float maxDistance = 2;
    public float timer = 1.0f;
    public float visionCheckRate = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(SeePlayer())
        {
            Debug.Log("See Player");
            ShootAtPlayer();
        }else Debug.Log("No Player");

    }

    void ShootAtPlayer(){
        Instantiate(fireball, transform.position, transform.rotation);
        // PlayerComponent pc =  hit.collider.gameObject.GetComponent<PlayerComponent>();
        // if (pc != null)
        // {
        //     pc.ProcessHit();
        // }
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

}
