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
    private void Start()
    {
        LearningSysInfo.LoadLocalClasses();
        for(int i=0;i<LearningSysInfo.Lessons.ToArray().Length;i++)
        {
            if(LearningSysInfo.Lessons[i].CourseType==1)
            {
                LearningSysInfo.CurrentAllNeedLesson = LearningSysInfo.Lessons[i];
                break;
            }
        }
        for(int i=0;i<LearningSysInfo.Lessons.ToArray().Length;i++)
        {
            if(LearningSysInfo.Lessons[i].CourseType==2)
            {
                LearningSysInfo.CurrentMajorNeedLesson = LearningSysInfo.Lessons[i];
                break;
            }
        }
        for (int i = 0; i < LearningSysInfo.Lessons.ToArray().Length; i++)
        {
            if (LearningSysInfo.Lessons[i].CourseType == 3)
            {
                LearningSysInfo.CurrentElectLesson = LearningSysInfo.Lessons[i];
                break;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetLearntClass()
    {

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
    public void SetLessonName()
    {
        Type1Name.text = LearningSysInfo.CurrentAllNeedLesson.CourseName;
        Type2Name.text = LearningSysInfo.CurrentMajorNeedLesson.CourseName;
        Type3Name.text = LearningSysInfo.CurrentElectLesson.CourseName;
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
            }
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
