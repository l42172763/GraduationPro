using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest : MonoBehaviour
{
    public mytxtIO io;
    public string tt;
    // Start is called before the first frame update
    void Start()
    {
        io = this.GetComponent<mytxtIO>();
        tt = Application.dataPath;
        io.WriteIntoTxt("11qq");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
