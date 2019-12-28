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
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Scale();

        transform.position = target.position + offset;
        transform.LookAt(target);
    }
    //缩放
    private void Scale()
    {
        float dis = offset.magnitude;
        dis += Input.GetAxis("Mouse ScrollWheel") * 60;
        Debug.Log("dis=" + dis);
        if (dis < 40) dis = 40;
        if(dis>500) dis = 500;
        offset = offset.normalized * dis;
    }
    //左右上下移动
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 pos = transform.position;
            Vector3 rot = transform.eulerAngles;

            //围绕原点旋转，也可以将Vector3.zero改为 target.position,就是围绕观察对象旋转
            transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * 20);
            transform.RotateAround(target.position, Vector3.left, Input.GetAxis("Mouse Y") * 20);
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            Debug.Log("x=" + x);
            Debug.Log("y=" + y);
            //控制移动范围
            if (x >60)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
            //  更新相对差值
           offset = transform.position - target.position;
        }

    }
}
