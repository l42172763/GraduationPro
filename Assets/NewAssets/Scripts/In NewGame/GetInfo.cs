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
    private void Start()
    {
        StudentNumIn = GameObject.FindGameObjectWithTag("StudentNumInput");
        MajorIn = GameObject.FindGameObjectWithTag("MajorInput");
        PasswordIn = GameObject.FindGameObjectWithTag("PasswordInput");
        BS = gameObject.GetComponent<ButtonSettings>();
    }
    public void SetValues()
    {
        AllStatics.CurrentInformation.studentNum = StudentNumIn.GetComponent<InputField>().text;
        AllStatics.CurrentInformation.studentMajor = MajorIn.GetComponent<InputField>().text;
        AllStatics.CurrentInformation.password = PasswordIn.GetComponent<InputField>().text;
        if (AllStatics.StudentInfoCheck()) BS.InGaming();
        else Debug.Log("error exit");
    }
}
