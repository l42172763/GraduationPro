using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavTest : MonoBehaviour
{
    public Vector3 targetpos;
    public NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = nav.destination;
        if(Vector3.Distance(transform.position,nav.destination)<=2)
        {
            nav.isStopped = true;
        }
    }
    public void SetNavDest(GameObject tar)
    {
        nav.isStopped = false;
        nav.SetDestination(tar.transform.position);
    }
}