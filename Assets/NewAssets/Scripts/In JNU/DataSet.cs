using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataSet : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;
    public Vector3 Savedpos;
    public string tt;
    public List<int> myintget;
    public List<string> mystringget;
    public GameObject thegirl;
    public string txtname = "girlpos";
    // Start is called before the first frame update
    void Start()
    {
        thegirl = GameObject.FindGameObjectWithTag("Local Player");
        FileInfo file = new FileInfo(Application.dataPath + "/my" + txtname + ".txt");
        if (file.Exists)
        {
            mystringget = mytxtIO.GetmyStringList(txtname);
            Savedpos.x = float.Parse(mystringget[0]);
            Savedpos.y = float.Parse(mystringget[1]);
            Savedpos.z = float.Parse(mystringget[2]);
            thegirl.transform.position = Savedpos;
            file.Delete();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Savedpos = thegirl.transform.position;
    }
    public void SaveData()
    {
        string ls;
        ls = thegirl.transform.position.x + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.position.y + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.position.z + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
    }
}
