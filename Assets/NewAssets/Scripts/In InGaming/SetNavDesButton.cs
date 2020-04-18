using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetNavDesButton : MonoBehaviour
{
    public Keyboardmoving kb;
    public NavTest nt;
    private void Start()
    {

    }
    public void NavDesSet(string Des)
    {
        kb.autogoing = true;
        nt.nav.isStopped = false;
        nt.SetNavDest(GameObject.Find(Des));
    }
    public void Dormins(int t)
    {
        kb.autogoing = true;
        nt.nav.isStopped = false;
        string s = "NavDormi" + t;
        nt.SetNavDest(GameObject.Find(s));
    }
    public void CancelNav()
    {
        kb.autogoing = false;
        nt.nav.isStopped = true;
    }
}
