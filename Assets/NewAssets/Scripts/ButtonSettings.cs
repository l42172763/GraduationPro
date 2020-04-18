using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour
{
    //切换场景
    public void InGaming()
    {
        SaveCurrentInfo();
        if (SceneManager.GetActiveScene().name != "InGaming")
        {
            SceneManager.LoadScene("InGaming");
        }
    }
    public void StartNewGame()
    {
        SaveCurrentInfo();
        if (SceneManager.GetActiveScene().name != "NewGame")
        {
            SceneManager.LoadScene("NewGame");
        }
    }
    public void BackToMenu()
    {
        SaveCurrentInfo();
        if(SceneManager.GetActiveScene().name!= "Start Menu")
        {
            SceneManager.LoadScene("Start Menu");
        }
    }

    public void ExitGame()
    {
        SaveCurrentInfo();
        Application.Quit();
    }
    //操纵相机视角
    public void ResetCamera()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>().CameraReset(0,0);
    }
    private void SaveCurrentInfo()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "NewGame":
                GameObject.Find("LoginSettings").GetComponent<LoginSettings>().SaveData();
                LocalInformation.ClearCurrents();
                break;
            case "InGaming":
                GameObject.Find("DataSaving").GetComponent<DataSet>().SaveSituation();
                break;
            default:break;
        }
    }
}