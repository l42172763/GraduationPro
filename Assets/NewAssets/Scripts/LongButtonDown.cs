using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LongButtonDown : MonoBehaviour
{
    public float Ping;
    private bool IsStart = false;
    private float LastTime = 0.1f;
    public GameObject t;
    public CameraController cc;
    public int DirectionType;
    void Update()
    {
        if (IsStart && Time.time - LastTime > Ping)
        {
            Debug.Log("长按触发");
            switch (DirectionType)
            {
                case 1:CameraLeft(Time.deltaTime); break;
                default:break;
            }
            IsStart = false;
            LastTime = 0;
        }
    }
    public void LongPress(bool bStart)
    {
        IsStart = bStart;
        LastTime = Time.time;
    }
    public void CameraLeft(float time)
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(1,time);
    }
    public void CameraRight(float time)
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(2, time);
    }
    public void CameraUp(float time)
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(3, time);
    }
    public void CameraDown(float time)
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(4, time);
    }
}
