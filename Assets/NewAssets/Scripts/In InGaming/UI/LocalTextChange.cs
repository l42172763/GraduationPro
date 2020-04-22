using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalTextChange : MonoBehaviour
{
    public Text edittext;
    public float time;
    public int tared;
    public String oritext;
    public String tartext1;
    public String tartext2;
    public String tartext3;
    // Start is called before the first frame update
    void Start()
    {
        //edittext = GetComponent<Text>();
        time = 0f;
        oritext = edittext.text;
        tartext1 = oritext + "。";
        tartext2 = tartext1 + "。";
        tartext3 = tartext2 + "。";
    }

    // Update is called once per frame
    void Update()
    {
        switch (tared)
        {
            case (0):
                if (time > 0.7)
                {
                    edittext.text = tartext1;
                    tared = 1;
                    time = 0f;
                }
                break;
            case(1):
                if (time > 0.4)
                {
                    edittext.text = tartext2;
                    tared = 2;
                    time = 0f;
                }
                break;
            case (2):
                if (time > 0.4)
                {
                    edittext.text = tartext3;
                    tared = 3;
                    time = 0f;
                }
                break;
            case (3):
                if (time > 0.4)
                {
                    edittext.text = oritext;
                    tared = 0;
                    time = 0f;
                }
                break;
            default:break;
        }
        time += Time.deltaTime;
    }
}
