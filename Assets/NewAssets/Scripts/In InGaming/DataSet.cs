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
    public Quaternion SavedQua;
    public string tt;
    public List<int> myintget;
    public List<string> mystringget;
    public GameObject thegirl;
    public string txtname = "girlpos";
    public bool PosSettled = true;
    public bool PosRead = false;
    // Start is called before the first frame update
    void Start()
    {
        thegirl = GameObject.FindGameObjectWithTag("Local Player");
        FileInfo file = new FileInfo(Application.dataPath + "/my" + txtname + ".txt");
        if (file.Exists)
        {
            PosRead = true;
            PosSettled = false;
            mystringget = mytxtIO.GetmyStringList(txtname);
            Savedpos.x = float.Parse(mystringget[0]);
            Savedpos.y = float.Parse(mystringget[1]);
            Savedpos.z = float.Parse(mystringget[2]);
            transform.position = Savedpos;
            GameObject.Find("NavDesAwakeSettings").GetComponent<SetNavDesButton>().NavDesSet(this.name);
            PosSettled = true;
            file.Delete();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(PosSettled&&PosRead&&
            !GameObject.FindGameObjectWithTag("Local Player").GetComponent<Keyboardmoving>().autogoing)
        {
            PosSettled = false;
            Savedpos.x = float.Parse(mystringget[3]);
            Savedpos.y = float.Parse(mystringget[4]);
            Savedpos.z = float.Parse(mystringget[5]);
            SavedQua.eulerAngles = Savedpos;
            thegirl.transform.rotation = SavedQua;
        }
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
