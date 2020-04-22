using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitcureForGirl : MonoBehaviour
{
    public GameObject t1;
    public GameObject t2;
    private Quaternion or;
    // Start is called before the first frame update
    void Start()
    {
        or = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (t1.transform.position + t2.transform.position) / 2;
        transform.rotation=or;
    }
}
