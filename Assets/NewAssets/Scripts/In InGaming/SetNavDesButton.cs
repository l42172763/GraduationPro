using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNavDesButton : MonoBehaviour
{
    public NavTest nt;
    private void Start()
    {
        nt = GameObject.FindGameObjectWithTag("Local Player").GetComponent<NavTest>();
    }
    public void Cross1()
    {
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navcross1"));
    }
    public void RedHouse()
    {
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navredhouse"));
    }
    public void Target()
    {
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navtarget"));
    }
    public void Canteen()
    {
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navcanteen"));
    }
    public void CancelNav()
    {
        nt.nav.isStopped = true;
    }
}
