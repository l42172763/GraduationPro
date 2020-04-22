using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LearningSysInfo
{
    public struct Lesson
    {
        public bool Learnt;//是否已学过
        public int CourseNum;//课程编号
        public int ContentType;//内容显示方式（超链接、文本、文件路径等）
        public string CourseName;//课程名称
        public string Contents;//内容数据
        public string PreClass;//前序课程
        public bool IsOKToLearn(Lesson PreJud)
        {
            return PreJud.Learnt;
        }
        public void Learning()
        {
            Learnt = true;
        }
        public void Start()
        {
            Learnt = false;
        }
    }
    public static List<Lesson> Lessons=new List<Lesson> { };
    public static Lesson CurrentLesson;
    public static Lesson ExampleLesson = new Lesson
    {
        CourseNum = 0,
        ContentType = 0,
        CourseName = "Default",
        Contents = "This is an example",
        PreClass = null
    };
    public static void AddLessons()//添加课程；添加前应将课程相关信息写入CurrentLesson
    {
        CurrentLesson.Learnt = false;
        Lessons.Add(CurrentLesson);
    }
    public static int LearnTheLesson(string Cname,int Cnum)
    {
        int i;
        for(i=0;i<Lessons.ToArray().Length;i++)
        {
            if(Lessons[i].CourseName==Cname&&Lessons[i].CourseNum==Cnum)
            {
                CurrentLesson = Lessons[i];
                return Learning()?1:0;
            }
        }
        return -1;
    }
    public static bool Learning()
    {
        Debug.Log(CurrentLesson.Contents);
        return true;
    }
}
