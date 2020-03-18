using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardmoving : MonoBehaviour
{
    private Rigidbody rBody;
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    public float jumpheight;
    public float easyrate;
    public float gravityrate;
    // Start is called before the first frame update
    void Start()
    {
        easyrate = 100f;
        gravityrate = 10f;
        rBody = this.GetComponent<Rigidbody>();
        jumpheight = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        jump();
    }
    private void movement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 v = rBody.velocity;
        v.y = -gravityrate;
        v.z = 0f;
        v.x = 0f;
        if (horizontal != 0 || vertical != 0)
        {
            v.z = -horizontal * easyrate;
            v.x = vertical * easyrate;
        }
        rBody.velocity = v;
    }
    private void jump()
    {
        Vector3 tt = transform.position;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            tt.y += jumpheight;
            transform.position = tt;
        }
    }
}
