using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowIntroduce : MonoBehaviour
{
    public string title = "建筑名";
    public string content = "建筑物介绍";

    private bool isShow = false;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Local Player")
        {
            isShow = true;
            UIShowIntroduce.Instance.StartIntroduce(title, content);
        }
    }

    void OnTriggerExit(Collider c)
    {
		if (c == null)
			return;
        if(isShow)
        {
            UIShowIntroduce.Instance.Close();
        }
    }
}
