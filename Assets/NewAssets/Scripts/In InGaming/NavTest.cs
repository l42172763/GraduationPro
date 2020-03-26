using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavTest : MonoBehaviour
{

    public Transform targetpos;
    public NavMeshAgent nav;
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(targetpos.position);
    }
    public void SetNavDest(GameObject tar)
    {
        nav.SetDestination(tar.transform.position);
    }
}