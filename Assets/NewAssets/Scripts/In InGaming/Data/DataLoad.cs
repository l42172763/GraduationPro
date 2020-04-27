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
    public List<string> mystringget;
    public string situationtxt;
    public string Classtxt;
    public bool PosSettled = true;
    public bool PosRead = false;
    public GameObject CoverImage;

    void Start()
    {
        LearningSysInfo.LoadSavedLinkOfSL();
        situationtxt = AllStatics.CurrentUser + "girlpos";//获取当前账户名用于设置此账户的角色位置信息存储
        thegirl = GameObject.FindGameObjectWithTag("Local Player");
        FileInfo file = new FileInfo(Application.dataPath + "/" + situationtxt + ".txt");
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
            AllStatics.NeedShowIntroduce = false;
            file.Delete();
        }
        else
        {
            CoverImage.GetComponent<LoadingControl>().ActiveThis();//关闭加载界面
            Destroy(gameObject, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PosSettled && PosRead &&
            !AllStatics.AutoNavingNow)
        {
            Savedpos.x = float.Parse(mystringget[3]);
            Savedpos.y = float.Parse(mystringget[4]);
            Savedpos.z = float.Parse(mystringget[5]);
            SavedQua.eulerAngles = Savedpos;
            thegirl.transform.rotation = SavedQua;
            PosSettled = true;
            CoverImage.GetComponent<LoadingControl>().ActiveThis();
            Destroy(gameObject, 0f);
        }
    }
}
