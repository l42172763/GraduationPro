using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    private Transform target;

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Local Player");
        target = player.transform;
        transform.position = target.position + offset;
        transform.LookAt(target);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Scale();
        transform.position = target.position + offset;

    }
    //缩放
    private void Scale()
    {
        float distance = offset.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * 60;
        Debug.Log("distance=" + distance);
        distance=Mathf.Clamp(distance,40, 500);
        offset = offset.normalized * distance;
    }
    //左右上下移动
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {

            //围绕原点旋转，也可以将Vector3.zero改为 target.position,就是围绕观察对象旋转
            transform.RotateAround(target.position, target.up, Input.GetAxis("Mouse X") * 20);

            Vector3 pos = transform.position;
            Vector3 rot = transform.eulerAngles;
            transform.RotateAround(target.position, target.right, -Input.GetAxis("Mouse Y") * 20);
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            //控制移动范围
            if (x < 10 || x > 60)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
            //  更新相对差值
           offset = transform.position - target.position;
        }

    }
}
