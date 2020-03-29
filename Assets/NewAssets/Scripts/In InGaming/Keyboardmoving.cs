using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboardmoving : MonoBehaviour
{
    [SerializeField] private Rigidbody rBody;
    public float horizontal;
    public float vertical;
    public float jumpheight;
    public float easyrate;
    public float gravityrate;//跳跃速度
    private float jumping;//跳跃时间
    public bool autogoing;//自动寻路中
    // Start is called before the first frame update
    void Start()
    {
        easyrate = 100f;
        gravityrate = 20f;
        rBody = this.GetComponent<Rigidbody>();
        jumpheight = 5f;
        jumping = 0f;
        autogoing = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        if (jumping > 0)
        {
            jumping -= Time.deltaTime;//更新冷却时间
        }
    }
    private void Movement()
    {
        Vector3 v = rBody.velocity;
        if (!autogoing)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            if (CanJump) v.y = -gravityrate;
            else v.y = gravityrate;
            v.z = 0f;
            v.x = 0f;
        }
        if (horizontal != 0 || vertical != 0)
        {
            v.z = -horizontal * easyrate;
            v.x = vertical * easyrate;
            RotateChange(horizontal > 0, vertical > 0, horizontal < 0, vertical < 0);
        }
        rBody.velocity = v;
    }
    private void Jump()
    {
        Vector3 tt = transform.position;
        if(Input.GetKeyDown(KeyCode.Space)&&CanJump)
        {
            //tt.y += jumpheight;
            transform.position = tt;
            jumping = 0.2f;//跳跃时长
        }
    }
    public bool CanJump
    {
        get
        {
            return jumping <= 0f;
        }
    }
    void RotateChange(bool ht, bool vt, bool hf, bool vf)
    {
        Quaternion rt;
        Vector3 re;
        rt = transform.rotation;
        re = rt.eulerAngles;
        if(ht)
        {
            if (vt)
            {
                re.y = 135;
            }
            else if (vf)
            {
                re.y = -135;
            }
            else re.y = 180;
        }
        else if(hf)
        {
            if (vt)
            {
                re.y = 45;
            }
            else if (vf)
            {
                re.y = -45;
            }
            else re.y = 0;
        }
        else
        {
            if (vt)
            {
                re.y = 90;
            }
            else if (vf)
            {
                re.y = -90;
            }
        }
        rt.eulerAngles = re;
        transform.rotation = rt;
    }
}
