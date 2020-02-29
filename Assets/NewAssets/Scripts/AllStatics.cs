using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AllStatics 
{
    public static bool TestMode = false;
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
