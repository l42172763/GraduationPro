using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TogglePosition : MonoBehaviour
{
    public GameObject PI;
    public Vector3 offset; 
    // Start is called before the first frame update
    void Start()
    {
        PI = GameObject.FindGameObjectWithTag("PasswordInput");
        offset.x = 350;
        offset.y = 0;
        offset.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PI.transform.position + offset;
    }
}
