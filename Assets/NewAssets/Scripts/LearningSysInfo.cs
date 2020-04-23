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
    public static Lesson CurrentAllNeedLesson = new Lesson { };
    public static Lesson CurrentMajorNeedLesson = new Lesson { };
    public static Lesson CurrentMajorElectLesson = new Lesson { };
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
        CurrentAllNeedLesson.Learnt = false;
        Lessons.Add(CurrentAllNeedLesson);
    }
    public static int LearnTheLesson(string Cname,int Cnum)
    {
        int i;
        for(i=0;i<Lessons.ToArray().Length;i++)
        {
            if(Lessons[i].CourseName==Cname&&Lessons[i].CourseNum==Cnum)
            {
                CurrentAllNeedLesson = Lessons[i];
                return Learning()?1:0;
            }
        }
        return -1;
    }
    public static bool Learning()
    {
        Debug.Log(CurrentAllNeedLesson.Contents);
        return true;
    }
    public static Lesson HighLevelMath = new Lesson
    {
        CourseName = "高等数学",
        CourseNum = 1,
        ContentType = 1,
        Contents = "指相对于初等数学而言，数学的对象及方法较为繁杂的一部分。广义地说，初等数学之外的数学都是高等数学，也有将中学较深入的代数、几何以及简单的集合论初步、逻辑初步称为中等数学的，将其作为中小学阶段的初等数学与大学阶段的高等数学的过渡。通常认为，高等数学是由微积分学，较深入的代数学、几何学以及它们之间的交叉内容所形成的一门基础学科。主要内容包括：数列、极限、微积分、空间解析几何与线性代数、级数、常微分方程。工科、理科、财经类研究生考试的基础科目。",
        PreClass = null
    };
}
