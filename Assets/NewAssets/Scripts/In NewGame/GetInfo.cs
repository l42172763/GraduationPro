using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetInfo : MonoBehaviour
{
    public GameObject StudentNumIn;
    public GameObject MajorIn;
    public GameObject PasswordIn;
    public ButtonSettings BS;
    public Image NewUserCheck;
    public Image WrongEntranceCheck;
    private void Start()
    {
        StudentNumIn = GameObject.FindGameObjectWithTag("StudentNumInput");
        MajorIn = GameObject.FindGameObjectWithTag("MajorInput");
        PasswordIn = GameObject.FindGameObjectWithTag("PasswordInput");
        BS = gameObject.GetComponent<ButtonSettings>();
    }
    public void SetValues()
    {
        LocalInformation.CurrentInformation.studentNum = StudentNumIn.GetComponent<InputField>().text;
        LocalInformation.CurrentInformation.studentMajor = MajorIn.GetComponent<InputField>().text;
        LocalInformation.CurrentInformation.password = PasswordIn.GetComponent<InputField>().text;
        switch (LocalInformation.StudentInfoCheck())
        {
            case 2:
                BS.InGaming();
                break;
            case 1:
                Debug.Log("wrong info");
                ClearInputF();
                WrongEntranceCheck.GetComponent<UITips>().onShow();
                break;
            case 0:
                Debug.Log("no info");
                ClearInputF();
                NewUserCheck.GetComponent<UITips>().onShow();
                break;
            default:break;
        }
    }
    private void ClearInputF()
    {
        StudentNumIn.GetComponent<InputField>().text = "";
        MajorIn.GetComponent<InputField>().text = "";
        PasswordIn.GetComponent<InputField>().text = "";
    }
}
