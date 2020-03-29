using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavTest : MonoBehaviour
{
    public Vector3 targetpos;
    public NavMeshAgent nav;
    public Keyboardmoving kb;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        kb = GameObject.FindGameObjectWithTag("Local Player").GetComponent<Keyboardmoving>();
    }

    // Update is called once per frame
    void Update()
    {
        targetpos = nav.destination;
        if(Vector3.Distance(transform.position,nav.destination)<=2)
        {
            kb.autogoing = false;
            nav.isStopped = true;
        }
    }
    public void SetNavDest(GameObject tar)
    {
        nav.isStopped = false;
        nav.SetDestination(tar.transform.position);
    }
}