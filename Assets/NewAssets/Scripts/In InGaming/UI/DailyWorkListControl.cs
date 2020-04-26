using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyWorkListControl : MonoBehaviour
{
    public GameObject Work1;
    public GameObject Work2;
    public GameObject Work3;
    public Text Type1Con;
    public Text Type1Name;
    public Text Type2Name;
    public Text Type3Name;
    private void Start()//加载时应读取三种类型的课程中各自的课程列表，等待DataLoad调用设置课程函数
    {
        LearningSysInfo.LoadLocalClasses();
        //下面按顺序读取课程中的三类课程
        for(int i=0;i<LearningSysInfo.Lessons.ToArray().Length;i++)
        {
            if(LearningSysInfo.Lessons[i].CourseType== 1 && !LearningSysInfo.Lessons[i].Learnt)
            {
                LearningSysInfo.CurrentAllNeedLesson = LearningSysInfo.Lessons[i];
                break;
            }
        }
        for(int i=0;i<LearningSysInfo.Lessons.ToArray().Length;i++)
        {
            if(LearningSysInfo.Lessons[i].CourseType==2 && !LearningSysInfo.Lessons[i].Learnt)
            {
                LearningSysInfo.CurrentMajorNeedLesson = LearningSysInfo.Lessons[i];
                break;
            }
        }
        for (int i = 0; i < LearningSysInfo.Lessons.ToArray().Length; i++)
        {
            if (LearningSysInfo.Lessons[i].CourseType == 3 && !LearningSysInfo.Lessons[i].Learnt)
            {
                LearningSysInfo.CurrentElectLesson = LearningSysInfo.Lessons[i];
                break;
            }
        }
    }

    void Update()
    {

    }

    public void SetLessonName()
    {
        Type1Name.text = LearningSysInfo.CurrentAllNeedLesson.CourseName;
        Type2Name.text = LearningSysInfo.CurrentMajorNeedLesson.CourseName;
        Type3Name.text = LearningSysInfo.CurrentElectLesson.CourseName;
    }

    public void SetLessonData(int type)
    {
        switch(type)
        {
            case 0:
                LearningSysInfo.CurrentLesson = LearningSysInfo.CurrentAllNeedLesson;
                switch (LearningSysInfo.CurrentAllNeedLesson.ContentType)
                {
                    case 1:
                        Type1Con.text = LearningSysInfo.CurrentAllNeedLesson.Contents;
                        break;
                    case 2:
                        Application.OpenURL(LearningSysInfo.CurrentAllNeedLesson.Contents);
                        break;
                    case 0:
                        break;
                    default: break;
                }
                break;
            case 1:
                LearningSysInfo.CurrentLesson = LearningSysInfo.CurrentMajorNeedLesson;
                switch (LearningSysInfo.CurrentMajorNeedLesson.ContentType)
                {
                    case 1:
                        Type1Con.text = LearningSysInfo.CurrentMajorNeedLesson.Contents;
                        break;
                    case 2:
                        Application.OpenURL(LearningSysInfo.CurrentMajorNeedLesson.Contents);
                        break;
                    case 0:
                        break;
                    default: break;
                }
                break;
            case 2:
                LearningSysInfo.CurrentLesson = LearningSysInfo.CurrentElectLesson;
                switch (LearningSysInfo.CurrentElectLesson.ContentType)
                {
                    case 1:
                        Type1Con.text = LearningSysInfo.CurrentElectLesson.Contents;
                        break;
                    case 2:
                        Application.OpenURL(LearningSysInfo.CurrentElectLesson.Contents);
                        break;
                    case 0:
                        break;
                    default: break;
                }
                break;
            default:break;
        }
    }
    public void SetNextLesson()
    {
        if(AllStatics.TestMode)
        {
            Debug.Log("TestMode");
        }
        else
        {
            for (int i = 0; i < LearningSysInfo.Lessons.ToArray().Length; i++)
            {
                if (LearningSysInfo.Lessons[i].CourseName == LearningSysInfo.CurrentLesson.CourseName)
                {
                    LearningSysInfo.Lessons[i].LearnThisClass();
                }
            }//设置此课程为已学过
            for(int i=0;i <LearningSysInfo.StudentCourseInfo.ToArray().Length;i++)
            {
                if (LearningSysInfo.StudentCourseInfo[i].StuNum==AllStatics.CurrentUser)
                {
                    LearningSysInfo.StudentCourseInfo[i].LearntLessons.Add
                        (LearningSysInfo.CurrentLesson.CourseName);
                    goto switcher;
                }
            }//设置当前用户已学过此课程
            LearningSysInfo.StudentsLessons ForAddSLInfo = new LearningSysInfo.StudentsLessons { };
            ForAddSLInfo.StuNum = AllStatics.CurrentUser;
            ForAddSLInfo.LearntLessons = new List<string> { };
            ForAddSLInfo.LearntLessons.Add(LearningSysInfo.CurrentLesson.CourseName);
            ForAddSLInfo.AddIntoInfoList();
            switcher:
            switch (LearningSysInfo.CurrentLesson.CourseType)
            {
                case 1:
                    for (int i = 0; i < LearningSysInfo.Lessons.ToArray().Length; i++)
                    {
                        if (LearningSysInfo.Lessons[i].CourseName == LearningSysInfo.CurrentAllNeedLesson.NextClass)
                        {
                            LearningSysInfo.CurrentAllNeedLesson = LearningSysInfo.Lessons[i];
                            if (LearningSysInfo.CurrentAllNeedLesson.Learnt)
                            {
                                i = 0;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < LearningSysInfo.Lessons.ToArray().Length; i++)
                    {
                        if (LearningSysInfo.Lessons[i].CourseName == LearningSysInfo.CurrentMajorNeedLesson.NextClass)
                        {
                            LearningSysInfo.CurrentMajorNeedLesson = LearningSysInfo.Lessons[i];
                            break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < LearningSysInfo.Lessons.ToArray().Length; i++)
                    {
                        if (LearningSysInfo.Lessons[i].CourseName == LearningSysInfo.CurrentElectLesson.NextClass)
                        {
                            LearningSysInfo.CurrentElectLesson = LearningSysInfo.Lessons[i];
                            if(LearningSysInfo.CurrentElectLesson.Learnt)
                            {
                                i = 0;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
