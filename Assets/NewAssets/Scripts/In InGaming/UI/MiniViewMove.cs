using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniViewMove : MonoBehaviour
{
    private Vector3 th;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        th = this.GetComponentInParent<Transform>().position;
        th.y += 400;
        transform.position = th;
    }
}
