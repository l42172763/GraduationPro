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
    public bool autogoing;//自动寻路中
    public float speed;
    public GameObject caca;
    // Start is called before the first frame update
    void Start()
    {
        easyrate = 100f;
        rBody = this.GetComponent<Rigidbody>();
        autogoing = false;
        speed = 100f;
        caca = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void Movement()
    {
        Vector3 v = rBody.velocity;
        if (!autogoing)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            v.z = 0f;
            v.x = 0f;
        }
        if (horizontal != 0 || vertical != 0)
        {
            Vector3 targetDirection = new Vector3(horizontal, 0, vertical);
            float y = caca.transform.rotation.eulerAngles.y;
            targetDirection = Quaternion.Euler(0, y, 0) * targetDirection;
            //caca.transform.Translate(targetDirection * Time.deltaTime * speed, Space.World);
            transform.Translate(targetDirection * Time.deltaTime * speed, Space.World);
            transform.LookAt(transform.position+ targetDirection);
        }
    }
}
