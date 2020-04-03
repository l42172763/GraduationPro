using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalInformation
{
    public static bool TestMode = false;
    public static int ScenesNumber;
    private static bool AddInfoAllowed = false;
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
    public static UserInfo CurrentInformation;
    private static List<UserInfo> CurrentInformations= new List<UserInfo> { };
    private static UserInfo SavedInformation = new UserInfo
    { studentName = "creation", studentMajor = "信息安全", studentNum = "2016050216", password = "123" };
    public static int StudentInfoCheck()
    {
        if(SavedInformation.studentNum=="2016050216")
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
                    return 2;//找到输入信息且其他属性正确，允许登陆
                else return 1;//找到输入信息但其他属性不正确，不允许登陆
            }
        }
        if (true)
        {
            AllowAddInfo();
        }
        return 0;//未找到账户信息
    }
    private static bool DataIn()
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
    private static void AllowAddInfo()
    {
        AddInfoAllowed = true;
    }
    public static void PubAllowAddInfo()
    {
        AllowAddInfo();
    }
    public static bool StudentInfoAdd()//添加账户信息
    {
        if (AddInfoAllowed)//判断是否有权添加
        {
            AddInfoAllowed = false;
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
    public static void ClearCurrents()
    {
        CurrentInformations.Clear();
        CurrentInformation = new UserInfo { };
    }
}