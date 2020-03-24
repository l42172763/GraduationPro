using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLeaderSettings : MonoBehaviour
{
    public GameObject target;
    public Keyboardmoving kbm;
    public bool horing = false;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("DormitoryA (2)");
        kbm = this.GetComponent<Keyboardmoving>();
        horing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(horing)
        {
            kbm.horizontal = target.transform.position.x - transform.position.x > 0 ? -1 : 1;
            kbm.vertical = 0;
        }
        else
        {
            kbm.vertical = target.transform.position.x - transform.position.x > 0 ? 1 : -1;
            kbm.horizontal = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch(other.tag)
        {
            case "TurningAlert": ChangeDirection();break;
            case "DormiTrigger":kbm.autogoing = false;break;
            default:break;
        }
    }
    void ChangeDirection()
    {
        if (horing) horing = false;
        else horing = true;
       /* if(kbm.horizontal==0&&kbm.vertical!=0)
        {
            kbm.vertical = 0;
            kbm.horizontal= target.transform.position.x - target.transform.position.x > 0 ? 1 : -1;
        }
        else if (kbm.horizontal != 0 && kbm.vertical == 0)
        {
            kbm.horizontal = 0;
            kbm.vertical = target.transform.position.x - target.transform.position.x > 0 ? -1 : 1;
        }*/
    }
}
