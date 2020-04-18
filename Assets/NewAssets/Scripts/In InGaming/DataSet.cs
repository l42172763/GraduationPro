using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataSet : MonoBehaviour
{
    public GameObject thegirl;
    public string txtname = "girlpos";
    // Start is called before the first frame update
    void Start()
    {
        thegirl = GameObject.FindGameObjectWithTag("Local Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SaveSituation()
    {
        string ls;
        ls = thegirl.transform.position.x + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.position.y + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.position.z + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.rotation.eulerAngles.x + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.rotation.eulerAngles.y + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.rotation.eulerAngles.z + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
    }
}
