using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AllStatics 
{
    public static bool TestMode = false;//测试模式
    public static bool AutoNavingNow = false;//角色是否正在进行自动寻路
    public static bool NeedShowIntroduce = false;//是否显示场景介绍
    public static int ScenesNumber;
    public struct StudentInfo
    {
        public string studentName;//姓名
        public string studentMajor;//专业
        public string studentNum;//学号
        public string password;//密码
    };
    public static StudentInfo CurrentInformation;
    private static List<StudentInfo> CurrentInformations;
    private static StudentInfo SavedStudentInformation = new StudentInfo
    { studentName = "creation", studentMajor = "信息安全", studentNum = "2016050216", password = "123" };
    public static bool StudentInfoCheck()
    {
        if (CurrentInformation.studentNum == SavedStudentInformation.studentNum
            && CurrentInformation.studentMajor == SavedStudentInformation.studentMajor
            && CurrentInformation.password == SavedStudentInformation.password)
            return true;
        else return false;
    }
}
