using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    public float minimumY = -30F;
    public float maximumY = 10F;
    public float rotationY;
    public Vector3 offset;
    public Vector3 OriOffset;
    public UnityEngine.Quaternion OriRotation;
    private Transform target;
    private Transform startposition;
    private bool getplayer;
    public ETCJoystick lookJoystick;
    // Use this for initialization
    void Start()
    {
        sensitivityX=1f;//镜头移动速度--左右
        sensitivityY =1f;//镜头移动速度--上下
        minimumY = -30F;//镜头移动范围--下
        maximumY = 10F;//镜头移动范围--上
        lookJoystick = ETCInput.GetControlJoystick("CameraJoystick");
        OriOffset = offset;
        GameObject player;
        if (player = GameObject.FindGameObjectWithTag("Local Player"))
        {
            getplayer = true;
            target = player.transform;
            startposition = target;
            transform.position = target.position + offset;
            transform.LookAt(target);
            OriRotation = transform.rotation;
            rotationY = -OriRotation.eulerAngles.x;
        }
        else
        {
            getplayer = false;
            target = this.transform;
            transform.position += offset;
            //transform.LookAt(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate();
        NewRotate();
        Scale();
        transform.position = target.position + (getplayer? offset : Vector3.zero);
    }
    //缩放
    private void NewRotate()
    {
        if (lookJoystick.axisX.axisValue != 0 || lookJoystick.axisY.axisValue != 0)
        {
            float rotationX = transform.localEulerAngles.y + lookJoystick.axisX.axisValue * sensitivityX;
            rotationY += lookJoystick.axisY.axisValue * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
            Refresh();
        }
    }
    private void Scale()
    {
        float distance = offset.magnitude;
        distance += Input.GetAxis("Mouse ScrollWheel") * -60;
        //Debug.Log("distance=" + distance);
        distance=Mathf.Clamp(distance,40, 500);
        offset = offset.normalized * distance;
    }
    //左右上下移动
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {

            //围绕原点旋转，也可以将Vector3.zero改为 target.position,就是围绕观察对象旋转
            transform.RotateAround(target.position, target.up, Input.GetAxis("Mouse X") * 3);
            transform.RotateAround(target.position, transform.right, -Input.GetAxis("Mouse Y") * 3);
            //上一行将target.right修改为transform.right解决了视角切换的问题
            Vector3 pos = transform.position;
            Vector3 rot = transform.eulerAngles;
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            //控制移动范围
            if (x < 10 || x > 60)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
        }

    }
    private void Refresh()
    {
        //  更新相对差值
        offset = transform.position - startposition.position;
    }
    public void CameraReset(int cr,float tt)
    {
        switch (cr)
        {
            case 0:
                offset = OriOffset;
                transform.rotation = OriRotation;
                transform.position = startposition.position + offset;
                rotationY = -OriRotation.eulerAngles.x;
                break;
            case 1:
                transform.RotateAround(target.position, target.up, -0.5f * tt);
                break;
            case 2:
                transform.RotateAround(target.position, target.up, 0.5f * tt);
                break;
            case 3:
                transform.RotateAround(target.position, transform.right, -0.5f * tt);
                break;
            case 4:
                transform.RotateAround(target.position, transform.right, 0.5f * tt);
                break;
            default:break;
        }
        Vector3 pos = transform.position;
        Vector3 rot = transform.eulerAngles;
        float x = transform.eulerAngles.x;
        float y = transform.eulerAngles.y;
        //控制移动范围
        if (x < 10 || x > 60)
        {
            transform.position = pos;
            transform.eulerAngles = rot;
        }
        //  更新相对差值
        Refresh();
    }
}
