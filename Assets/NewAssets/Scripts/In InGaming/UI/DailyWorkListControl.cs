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
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAllNeedLessonData()
    {
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
            default:break;
        }
    }
    public void SetAllNeedLessonName()
    {
        Type1Name.text = LearningSysInfo.CurrentAllNeedLesson.CourseName;
    }
}
