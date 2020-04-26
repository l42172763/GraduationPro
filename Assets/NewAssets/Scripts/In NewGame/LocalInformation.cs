using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LocalInformation//登录界面的本地数据
{
    public static bool TestMode = false;
    public static int ScenesNumber;
    private static bool AddInfoAllowed = false;
    public static string InfoSaveName = "LoginInfo";
    /// <summary>
    /// 有关本地信息处理
    /// </summary>
    public struct UserInfo
    {
        public string studentName;//姓名
        public string studentMajor;//专业
        public string studentNum;//学号
        public string password;//密码
    };
    public static UserInfo CurrentInformation = new UserInfo { };
    private static List<UserInfo> CurrentInformations= new List<UserInfo> { };
    private static UserInfo SavedInformation = new UserInfo//默认账户
    {
        studentName = "creation",
        studentMajor = "信息安全",
        studentNum = "2016050216",
        password = "123",
    };
    public static int StudentInfoCheck()
    {
        if(SavedInformation.studentNum=="2016050216")//读取默认账户
        {
            DataIn();
        }
        else
        {
            SavedInformation = CurrentInformation;
        }
        for (int i = 0; i < CurrentInformations.ToArray().Length; i++)
        {

            if (CurrentInformation.studentNum == CurrentInformations[i].studentNum)
            {

                if (CurrentInformation.studentMajor == CurrentInformations[i].studentMajor
                && CurrentInformation.password == CurrentInformations[i].password)
                {//判断输入的学号存在后，验证账户信息，此处并没有用到用户姓名
                    AllStatics.CurrentUser = CurrentInformation.studentNum;
                    Debug.Log("登录账户：" + AllStatics.CurrentUser);
                    return 2;//找到输入信息且其他属性正确，允许登陆
                }
                else return 1;//找到输入信息但其他属性不正确，不允许登陆
            }
        }
        if (AllStatics.TestMode)
        {
            AddInfoAllowed = true;
        }
        return 0;//未找到账户信息
    }
    private static bool DataIn()//写入SavedInformation中的数据
    {
        for (int i = 0; i < CurrentInformations.ToArray().Length; i++)
        {

            if (CurrentInformations[i].studentNum == SavedInformation.studentNum)
            {
                return false;
            }
        }
        CurrentInformations.Add(SavedInformation);
        return true;
    }
    public static void PubAllowAddInfo()//外界申请写入数据的执行函数
    {
        AddInfoAllowed = true;
    }
    public static void PubRefuseAddInfo()//外界关闭写入数据的执行函数
    {
        AddInfoAllowed = false;
    }
    public static bool StudentInfoAdd()//添加账户信息
    {
        if (AddInfoAllowed)//判断是否有权添加
        {
            AddInfoAllowed = false;
            for(int i=0;i<CurrentInformations.ToArray().Length;i++)
            {
                if(CurrentInformations[i].studentNum==CurrentInformation.studentNum)
                {
                    return false;//信息重复，添加失败
                }
            }
            CurrentInformations.Add(CurrentInformation);
            return true;//添加成功
        }
        else return false;//无权添加
    }
    public static bool CheckAllowance()//检查是否允许添加信息
    {
        return AddInfoAllowed;
    }
    public static void RebuildData()
    {
        FileInfo file = new FileInfo(Application.dataPath + "/" + LocalInformation.InfoSaveName + ".txt");
        if (file.Exists)
        {
            file.Delete();//销毁此时存储的信息，便于重新生成数据文件
        }
    }
    public static void SaveData()//依次保存所有的当前存储的账户信息
    {
        string ls;
        for (int i = 0; i < CurrentInformations.ToArray().Length; i++)
        {
            ls = CurrentInformations[i].studentNum + "";
            mytxtIO.WriteIntoStringTxt(ls, InfoSaveName);
            ls = CurrentInformations[i].studentMajor + "";
            mytxtIO.WriteIntoStringTxt(ls, InfoSaveName);
            ls = CurrentInformations[i].password + "";
            mytxtIO.WriteIntoStringTxt(ls, InfoSaveName);
        }
    }
    public static void ClearCurrents()
    {
        CurrentInformations.Clear();
        CurrentInformation = new UserInfo { };
    }
}