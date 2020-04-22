using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIntroduce : MonoBehaviour
{
    public string title = "建筑名";
    public string content = "建筑物介绍";
    public bool isShow = false;
    public GameObject IntroUI;
    public bool jud;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Local Player" && !isShow)
        {
            isShow = true;
            UIShowIntroduce.Instance.StartIntroduce(title, content);
        }
    }
    void OnTriggerStay(Collider c)
    {
        jud = c.gameObject.tag == "Local Player" && !(isShow && IntroUI.gameObject.activeSelf);
        if (jud)
        {
            isShow = true;
            UIShowIntroduce.Instance.StartIntroduce(title, content);
        }
    }

    void OnTriggerExit(Collider c)
    {
		if (c == null)
        {
            return;
        }

        if (isShow && c.gameObject.tag == "Local Player")
        {
            UIShowIntroduce.Instance.Close();
            isShow = false;
        }
    }
}
