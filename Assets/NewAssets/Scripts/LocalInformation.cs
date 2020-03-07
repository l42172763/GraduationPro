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
    private static List<UserInfo> CurrentInformations;
    private static UserInfo SavedInformation = new UserInfo
    { studentName = "creation", studentMajor = "信息安全", studentNum = "2016050216", password = "123" };
    public static int StudentInfoCheck()
    {
        for (int i = 0; i < CurrentInformations.ToArray().Length; i++)
        {

            if (CurrentInformation.studentNum == SavedInformation.studentNum)
            {

                if (CurrentInformation.studentMajor == SavedInformation.studentMajor
                && CurrentInformation.password == SavedInformation.password)
                    return 2;//找到输入信息且其他属性正确，允许登陆
                else return 1;//找到输入信息但其他属性不正确，不允许登陆
            }
        }
        return 0;//未找到账户信息
    }
    public static void AllowAddInfo()
    {
        AddInfoAllowed = true;
    }
    public static bool StudentInfoAdd(UserInfo Usin)//添加账户信息
    {
        if (AddInfoAllowed)//判断是否有权添加
        {
            AddInfoAllowed = false;
            CurrentInformations.Add(Usin);
            return true;//添加成功
        }
        else return false;//无权添加
    }
}