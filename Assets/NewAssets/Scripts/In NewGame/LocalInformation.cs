using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalInformation
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
        public int LearntClassAmount;//已学课程数
        public List<string> LearntClasses;//已学课程
        public int ResetAmount()
        {
            LearntClassAmount = LearntClasses.ToArray().Length;
            return LearntClassAmount;
        }
        public int ClassAdd(string AddClass)
        {
            LearntClasses.Add(AddClass);
            LearntClassAmount = LearntClasses.ToArray().Length;
            return LearntClassAmount;
        }
    };
    public static UserInfo CurrentInformation = new UserInfo { };
    private static List<UserInfo> CurrentInformations= new List<UserInfo> { };
    private static UserInfo SavedInformation = new UserInfo//默认账户
    {
        studentName = "creation",
        studentMajor = "信息安全",
        studentNum = "2016050216",
        password = "123",
        LearntClassAmount = 0
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
                {
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
    public static bool CheckAllowance()
    {
        return AddInfoAllowed;
    }
    public static bool LoadData(int i)
    {
        if (i < CurrentInformations.ToArray().Length)
        {
            CurrentInformation = CurrentInformations[i];
            return true;
        }
        else return false;
    }


    public static int NewClassLearnt(string TheClass,string User)//添加新的已学课程
    {
        for(int i=0;i<CurrentInformations.ToArray().Length;i++)
        {
            if (CurrentInformations[i].studentNum == User)
            {
                int t = CurrentInformations[i].ResetAmount();
                return CurrentInformations[i].ClassAdd(TheClass);
            }
        }
        return -1;
    }


    public static void SaveData()
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
            //ls = CurrentInformations[i].LearntClassAmount + "";
            //mytxtIO.WriteIntoStringTxt(ls, InfoSaveName);
            for (int j = 0; j < CurrentInformations[i].LearntClasses.ToArray().Length; j++)
            {
                ls = CurrentInformation.LearntClasses[j] + "";
                mytxtIO.WriteIntoStringTxt(ls, InfoSaveName);
            }
            ls = "endInfo";
            mytxtIO.WriteIntoStringTxt(ls, InfoSaveName);
        }
    }
    public static void ClearCurrents()
    {
        CurrentInformations.Clear();
        CurrentInformation = new UserInfo { };
    }
}