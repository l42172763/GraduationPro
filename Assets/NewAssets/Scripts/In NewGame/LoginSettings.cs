using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoginSettings : MonoBehaviour
{
    public GameObject InfoBase;
    public GameObject TextCon;
    public GameObject SuccessAddInfo;
    public GameObject FailAddInfo;
    public GameObject NewInfoGetBase;
    public GameObject WhiteBackground;
    public List<string> Infoget;
    public void CreatNew()
    {
        NewInfoGetBase.GetComponent<UITips>().onOK();
        WhiteBackground.SetActive(true);
        if (LocalInformation.StudentInfoAdd())
        {
            SuccessAddInfo.GetComponent<UITips>().onShow();
        }
        else
        {
            FailAddInfo.GetComponent<UITips>().onShow();
        }
    }
    public void AffirmInfo()
    {
        InfoBase.GetComponent<UITips>().onShow();
        TextCon.GetComponent<Text>().text =
            "请确认您正在创建的账户信息为：" +
            "\n学号：" + LocalInformation.CurrentInformation.studentNum +
            "\n专业：" + LocalInformation.CurrentInformation.studentMajor +
            "\n密码" + LocalInformation.CurrentInformation.password;
    }
    void Start()
    {
        WhiteBackground.SetActive(false);
        FileInfo file = new FileInfo(Application.dataPath + "/" + LocalInformation.InfoSaveName + ".txt");
        if (file.Exists)
        {
            Infoget = mytxtIO.GetmyStringList(LocalInformation.InfoSaveName);
            for(int i=0;i<Infoget.ToArray().Length;i++)
            {
                LocalInformation.PubAllowAddInfo();
                LocalInformation.CurrentInformation.studentNum = Infoget[i];
                Debug.Log(LocalInformation.CurrentInformation.studentNum);
                LocalInformation.CurrentInformation.studentMajor = Infoget[++i];
                LocalInformation.CurrentInformation.password = Infoget[++i];
                LocalInformation.CurrentInformation.LearntClasses = new List<string> { };
                while (Infoget[++i]!="endInfo")
                {
                    LocalInformation.CurrentInformation.LearntClasses.Add(Infoget[++i]);
                }
                LocalInformation.StudentInfoAdd();
            }
            LocalInformation.PubRefuseAddInfo();
            file.Delete();
        }
    }
    
}
