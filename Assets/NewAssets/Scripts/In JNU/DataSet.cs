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
    public mytxtIO io;
    public string tt;
    public List<int> myintget;
    public List<string> mystringget;
    public GameObject thegirl;
    // Start is called before the first frame update
    void Start()
    {
        io = GameObject.Find("DataSaving").GetComponent<mytxtIO>();
        thegirl = GameObject.FindGameObjectWithTag("Local Player");
        mystringget = io.GetmyStringList();
        Savedpos.x = float.Parse(mystringget[0]);
        Savedpos.y = float.Parse(mystringget[1]);
        Savedpos.z = float.Parse(mystringget[2]);
        thegirl.transform.position = Savedpos;
    }

    // Update is called once per frame
    void Update()
    {
        //Savedpos = thegirl.transform.position;
    }
    public void SaveData()
    {
        FileInfo stringfile = new FileInfo(Application.dataPath + "/mystring.txt");
        if (stringfile.Exists)
        {
            stringfile.Delete();
            stringfile.Refresh();
        }
        string ls;
        ls = thegirl.transform.position.x + "";
        io.WriteIntoStringTxt(ls);
        ls = thegirl.transform.position.y + "";
        io.WriteIntoStringTxt(ls);
        ls = thegirl.transform.position.z + "";
        io.WriteIntoStringTxt(ls);
    }
}
