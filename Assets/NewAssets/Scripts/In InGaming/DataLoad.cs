using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class DataLoad : MonoBehaviour
{
    public GameObject thegirl;
    public Vector3 Savedpos;
    public Quaternion SavedQua;
    public List<int> myintget;
    public List<string> mystringget;
    public string situationtxt = "girlpos";
    public bool PosSettled = true;
    public bool PosRead = false;
    public GameObject UIshow;
    public string UIshowIntrotxt = "UIIntroduce";
    // Start is called before the first frame update
    void Start()
    {
        thegirl = GameObject.FindGameObjectWithTag("Local Player");
        FileInfo file = new FileInfo(Application.dataPath + "/my" + situationtxt + ".txt");
        if (file.Exists)
        {
            PosRead = true;
            PosSettled = false;
            mystringget = mytxtIO.GetmyStringList(situationtxt);
            Savedpos.x = float.Parse(mystringget[0]);
            Savedpos.y = float.Parse(mystringget[1]);
            Savedpos.z = float.Parse(mystringget[2]);
            transform.position = Savedpos;
            PosSettled = true;
            GameObject.Find("NavDesAwakeSettings").GetComponent<SetNavDesButton>().NavDesSet(this.name);
            file.Delete();
        }
        else
        {
            //Destroy(gameObject, 0f);
        }
        /*file = new FileInfo(Application.dataPath + "/my" + UIshowIntrotxt + ".txt");
        if (file.Exists)
        {
            PosRead = true;
            PosSettled = false;
            mystringget = mytxtIO.GetmyStringList(UIshowIntrotxt);
            UIshow.GetComponent<UIShowIntroduce>().needshow = bool.Parse(mystringget[0]);
            file.Delete();
        }
        if(!PosRead)
        {
            //Destroy(gameObject, 0f);
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (PosSettled && PosRead &&
            !GameObject.FindGameObjectWithTag("Local Player").GetComponent<Keyboardmoving>().autogoing)
        {
            Savedpos.x = float.Parse(mystringget[3]);
            Savedpos.y = float.Parse(mystringget[4]);
            Savedpos.z = float.Parse(mystringget[5]);
            SavedQua.eulerAngles = Savedpos;
            thegirl.transform.rotation = SavedQua;
            PosSettled = true;
            //Destroy(gameObject, 0f);
        }
    }
}
