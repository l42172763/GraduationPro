using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    public void ActiveThis()
    {
        gameObject.SetActive(false);
    }
}
