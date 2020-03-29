using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNavDesButton : MonoBehaviour
{
    public Keyboardmoving kb;
    public NavTest nt;
    private void Start()
    {
        nt = GameObject.FindGameObjectWithTag("Local Player").GetComponent<NavTest>();
        kb = GameObject.FindGameObjectWithTag("Local Player").GetComponent<Keyboardmoving>();
    }
    public void Cross1()
    {
        kb.autogoing = true;
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navcross1"));
    }
    public void RedHouse()
    {
        kb.autogoing = true;
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navredhouse"));
    }
    public void Target()
    {
        kb.autogoing = true;
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navtarget"));
    }
    public void Canteen()
    {
        kb.autogoing = true;
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find("Navcanteen"));
    }
    public void CancelNav()
    {
        kb.autogoing = false;
        nt.nav.isStopped = true;
    }
}
