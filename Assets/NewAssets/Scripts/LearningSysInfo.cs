using System.Collections;
using System.Collections.Generic;
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
        public void Add()
        {
            this.Learnt = false;
            Lessons.Add(this);
        }
        public bool LearnThisClass()
        {
            Learnt = true;
            Debug.Log(LocalInformation.NewClassLearnt(CourseName, AllStatics.CurrentUser));
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
        AllmyClasses= mytxtIO.StraightString(ClassFile);
        for(int i=0;i<AllmyClasses.ToArray().Length;i++)
        {
            ForAddLesson.CourseName = AllmyClasses[i];
            ForAddLesson.CourseNum = int.Parse(AllmyClasses[++i]);
            ForAddLesson.CourseType = int.Parse(AllmyClasses[++i]);
            ForAddLesson.ContentType = int.Parse(AllmyClasses[++i]);
            ForAddLesson.Contents = AllmyClasses[++i];
            i++;
            ForAddLesson.NextClass = AllmyClasses[i] == "null" ? null : AllmyClasses[i];
            ForAddLesson.Add();
        }
    }
    public static Lesson HighLevelMath = new Lesson
    {
        CourseName = "高等数学",
        CourseNum = 1,
        CourseType = 1,//通识必修课
        ContentType = 1,
        Contents = "指相对于初等数学而言，数学的对象及方法较为繁杂的一部分。广义地说，初等数学之外的数学都是高等数学，也有将中学较深入的代数、几何以及简单的集合论初步、逻辑初步称为中等数学的，将其作为中小学阶段的初等数学与大学阶段的高等数学的过渡。通常认为，高等数学是由微积分学，较深入的代数学、几何学以及它们之间的交叉内容所形成的一门基础学科。主要内容包括：数列、极限、微积分、空间解析几何与线性代数、级数、常微分方程。工科、理科、财经类研究生考试的基础科目。",
        NextClass = "高等数学2"
    };
    public static Lesson HighLevelMath2 = new Lesson
    {
        CourseName = "高等数学2",
        CourseNum = 2,
        CourseType = 1,//通识必修课
        ContentType = 1,
        Contents = "一般认为，16世纪以前发展起来的各个数学学科总的是属于初等数学的范畴，因而，17世纪以后建立的数学学科基本上都是高等数学的内容。由此可见，高等数学的范畴无法用简单的几句话或列举其所含分支学科来说明。",
        NextClass = null
    };
    public static Lesson Java = new Lesson
    {
        CourseName = "Java程序设计",
        CourseNum = 101,
        CourseType = 2,//专业课
        ContentType = 2,
        Contents = "E:\\Java面向对象程序设计.pdf",
        NextClass = "Java实验"
    };
    public static Lesson JavaExp = new Lesson
    {
        CourseName = "Java实验",
        CourseNum = 102,
        CourseType = 2,//专业课
        ContentType = 2,
        Contents = "E:\\JAVA面向对....pdf",
        NextClass = null
    };
    public static Lesson ArtificialIntelligence = new Lesson
    {
        CourseName = "人工智能导论",
        CourseNum = 201,
        CourseType = 3,//选修课
        ContentType = 2,
        Contents = "https://www.icourse163.org/course/ZJUT-1002694018",
        NextClass = null
    };
}
