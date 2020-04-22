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
    public GameObject CoverImage;
    public string UIshowIntrotxt = "UIIntroduce";
    // Start is called before the first frame update
    void Start()
    {

        LearningSysInfo.CurrentLesson = LearningSysInfo.ExampleLesson;
        LearningSysInfo.AddLessons();
        LearningSysInfo.LearnTheLesson("Default", 0);


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
            UIshow.GetComponent<UIShowIntroduce>().needshow = false;
            file.Delete();
        }
        else
        {
            CoverImage.GetComponent<LoadingControl>().ActiveThis();
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
            UIshow.GetComponent<UIShowIntroduce>().needshow = true;
            CoverImage.GetComponent<LoadingControl>().ActiveThis();
            Destroy(gameObject, 0f);
        }
    }
}
