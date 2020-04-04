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
    public Vector3 Savedpos1;
    public Quaternion SavedQua;
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
            /*Savedpos.x = 0f;
            Savedpos.y = 0f;
            Savedpos.z = 0f;*/
            thegirl.transform.position = Savedpos;
            Savedpos1.x = float.Parse(mystringget[3]);
            Savedpos1.y = float.Parse(mystringget[4]);
            Savedpos1.z = float.Parse(mystringget[5]);
            SavedQua.eulerAngles = Savedpos1;
            thegirl.transform.rotation = SavedQua;
            file.Delete();
        }
    }

    // Update is called once per frame
    void Update()
    {

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
        ls = thegirl.transform.rotation.eulerAngles.x + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.rotation.eulerAngles.y + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
        ls = thegirl.transform.rotation.eulerAngles.z + "";
        mytxtIO.WriteIntoStringTxt(ls, txtname);
    }
}
