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
                Debug.Log("success entrance");//输入正确，进入游戏界面
                BS.InGaming();
                break;
            case 1:
                Debug.Log("wrong info");//输入信息错误，要求重新输入
                ClearInputF();
                WrongEntranceCheck.GetComponent<UITips>().onShow();
                break;
            case 0:
                Debug.Log("no info");//用户名不存在，若处于开发者模式则询问是否添加账户
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
