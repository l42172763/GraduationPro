using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoginSettings : MonoBehaviour//登录界面起始时读取数据
{
    public GameObject InfoBase;
    public GameObject TextCon;
    public GameObject SuccessAddInfo;
    public GameObject FailAddInfo;
    public GameObject NewInfoGetBase;
    public GameObject WhiteBackground;
    public List<string> Infoget;
    void Start()
    {
        WhiteBackground.SetActive(false);//关闭提示信息的背景白板
        FileInfo file = new FileInfo(Application.dataPath + "/" + LocalInformation.InfoSaveName + ".txt");
        if (file.Exists)
        {
            Infoget = mytxtIO.GetmyStringList(LocalInformation.InfoSaveName);
            for(int i=0;i<Infoget.ToArray().Length;i++)//从文件中读取数据并存储
            {
                LocalInformation.PubAllowAddInfo();
                LocalInformation.CurrentInformation.studentNum = Infoget[i];
                LocalInformation.CurrentInformation.studentMajor = Infoget[++i];
                LocalInformation.CurrentInformation.password = Infoget[++i];
                LocalInformation.StudentInfoAdd();
            }
            LocalInformation.PubRefuseAddInfo();
            file.Delete();//销毁所读取的文件便于离开此界面时重新存储
        }
        LocalInformation.SaveData();//立即重建存储内容，防止程序意外退出
    }
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
}
