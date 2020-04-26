using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class LearningSysInfo
{
    public static string ClassFile = "ClassesInfo";
    private static List<string> AllmyClasses = new List<string>();
    public struct Lesson
    {
        public bool Learnt;//是否已学过
        public int CourseNum;//课程编号
        public int CourseType;//课程类型（公共必修课、专业必修课、选修课）
        public int ContentType;//内容显示方式（超链接、文本、文件路径等）
        public string CourseName;//课程名称
        public string Contents;//内容数据
        public string NextClass;//下一课程
        public void AddToLessonsList()
        {
            this.Learnt = false;
            Lessons.Add(this);
        }
        public bool LearnThisClass()
        {
            Learnt = true;
            return Learnt;
        }
    }
    public static List<Lesson> Lessons=new List<Lesson> { };
    public static Lesson CurrentAllNeedLesson = new Lesson { };
    public static Lesson CurrentMajorNeedLesson = new Lesson { };
    public static Lesson CurrentElectLesson = new Lesson { };
    public static Lesson ForAddLesson = new Lesson { };
    public static Lesson CurrentLesson = new Lesson { };
    public static void AddLessons()//添加课程；添加前应将课程相关信息写入CurrentLesson
    {
        Lessons.Add(ForAddLesson);
    }
    public static void LoadLocalClasses()
    {
        FileInfo Classes = new FileInfo(Application.dataPath + "/" + "ClassInfo" + ".txt");
        if (Classes.Exists)
            AllmyClasses = mytxtIO.StraightString(ClassFile);//明文读取课程信息，若读取失败改从AllStatics中读取
        else AllmyClasses = AllStatics.DefaultClassesInfo;
        for(int i=0;i<AllmyClasses.ToArray().Length;i++)
        {
            ForAddLesson.CourseName = AllmyClasses[i];
            ForAddLesson.CourseNum = int.Parse(AllmyClasses[++i]);
            ForAddLesson.CourseType = int.Parse(AllmyClasses[++i]);
            ForAddLesson.ContentType = int.Parse(AllmyClasses[++i]);
            ForAddLesson.Contents = AllmyClasses[++i];
            i++;
            ForAddLesson.NextClass = AllmyClasses[i] == "null" ? null : AllmyClasses[i];
            ForAddLesson.AddToLessonsList();
        }
    }
    public struct StudentsLessons
    {
        public string StuNum;
        public List<string> LearntLessons;
        public bool AddIntoInfoList()//将当前信息添加至总list中
        {
            if (StuNum == null) return false;//此项目不存在，返回错误信息
            else
            {
                for(int i=0;i<StudentCourseInfo.ToArray().Length;i++)//遍历已存储信息，确保未被存储
                {
                    if(StuNum==StudentCourseInfo[i].StuNum)//若已存储此信息则更新之
                    {
                        StudentCourseInfo.Remove(StudentCourseInfo[i]);
                        StudentCourseInfo.Add(this);
                        return true;//更新完成
                    }
                }
                StudentCourseInfo.Add(this);
                return true;//添加成功
            }
        }
        /*public void AddLearntLesson(string CourseName)//添加已学过的课程
        {
            LearntLessons.Add(CourseName);
        }
        public void ResetLearntLesson()
        {
            LearntLessons.Clear();
        }*/
        public bool DeleteALesson(string CourseName)
        {
            for(int i=0;i<LearntLessons.ToArray().Length;i++)
            {
                if(LearntLessons[i]==CourseName)//发现了需要删除的已学课程
                {
                    List<string> ForDelete = new List<string> { };
                    for (int j=0;j< LearntLessons.ToArray().Length; j++)
                    {
                        if(j!=i)
                        {
                            ForDelete.Add(LearntLessons[i]);
                        }
                    }
                    LearntLessons = ForDelete;
                    return true;//删除成功
                }
            }
            return false;//未找到目标课程
        }
    }
    public static StudentsLessons SCInfo = new StudentsLessons { };
    public static List<StudentsLessons> StudentCourseInfo = new List<StudentsLessons> { };
    public static string StuLesTxt = "StuLesLink";
    public static void SaveLinkOfStuLes()//存储已保存的所有学生和课程信息
    {
        FileInfo Classes = new FileInfo(Application.dataPath + "/" + StuLesTxt + ".txt");
        if (Classes.Exists)
            Classes.Delete();//若文件存在则更新之
        string ls;
        for (int i = 0; i < StudentCourseInfo.ToArray().Length; i++)
        {
            ls = StudentCourseInfo[i].StuNum + "";
            mytxtIO.WriteIntoStringTxt(ls, StuLesTxt);
            for (int j=0;j<StudentCourseInfo[i].LearntLessons.ToArray().Length;j++)
            {
                ls = StudentCourseInfo[i].LearntLessons[j] + "";
                mytxtIO.WriteIntoStringTxt(ls, StuLesTxt);
            }
            ls = "EndThisCourse";
            mytxtIO.WriteIntoStringTxt(ls, StuLesTxt);
        }
    }
    public static void LoadSavedLinkOfSL()//读取已保存的学生和课程信息
    {
        FileInfo Classes = new FileInfo(Application.dataPath + "/" + StuLesTxt + ".txt");
        if (Classes.Exists)
        {
            List<string> SavedLOSL = mytxtIO.GetmyStringList(StuLesTxt);
            for (int i=0;i<SavedLOSL.ToArray().Length;i++)
            {
                SCInfo.StuNum = SavedLOSL[i++];
                while (SavedLOSL[i]!= "EndThisCourse")
                {
                    SCInfo.LearntLessons = new List<string> { };
                    SCInfo.LearntLessons.Add(SavedLOSL[i]);
                    i++;
                }
                SCInfo.AddIntoInfoList();
                SCInfo = new StudentsLessons { };//清空数据，准备下一轮读取
            }
        }
        else//若无本地信息则存入默认内容
        {
            SCInfo.StuNum = AllStatics.CurrentUser;
            SCInfo.LearntLessons = new List<string> { };
            SCInfo.AddIntoInfoList();
            SCInfo = new StudentsLessons { };
        }
    }
    public static void SetLearntCourses()//根据当前用户设置所有课程是否已学过
    {
        for(int i=0;i<StudentCourseInfo.ToArray().Length;i++)
        {
            if(StudentCourseInfo[i].StuNum==AllStatics.CurrentUser)//遍历寻找当前用户的信息
            {
                for(int j=0;j<StudentCourseInfo[i].LearntLessons.ToArray().Length;j++)//遍历当前用户已学课程
                {
                    for(int k=0;k<Lessons.ToArray().Length;k++)
                    {
                        if(Lessons[k].CourseName==StudentCourseInfo[i].LearntLessons[j])//遍历寻找已学课程对应信息
                        {
                            Lessons[k].LearnThisClass();//设置该课程为已学过
                        }
                    }
                }
            }
        }
    }
}
