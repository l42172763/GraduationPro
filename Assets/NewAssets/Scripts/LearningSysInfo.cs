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
        public bool isOKToLearn(Lesson PreJud)
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
    public static List<Lesson> Lessons;
    public static Lesson CurrentLesson;
    public static void AddLessons()
    {
        CurrentLesson.Learnt = false;
        Lessons.Add(CurrentLesson);
    }
}
