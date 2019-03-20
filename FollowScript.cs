using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowScript : MonoBehaviour
{
    public Transform target;
    Vector3 destination;
    NavMeshAgent agent;

    void Start()
    {
        // Cache agent component and destination
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    void Update()
    {
        
        destination = target.position;
        agent.destination = destination;
        transform.LookAt(destination);


        transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
    }
}
