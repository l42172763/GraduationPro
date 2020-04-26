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
        switch (SceneManager.GetActiveScene().name)//离开某个界面时，存储属于该界面的信息
        {
            case "Start Menu":
                break;
            case "NewGame":
                LocalInformation.RebuildData();//删除已存储的信息
                LocalInformation.SaveData();//重建本地文件进行存储
                LocalInformation.ClearCurrents();
                break;
            case "InGaming":
                GameObject.Find("DataSaving").GetComponent<DataSet>().SaveSituation();//存储玩家位置
                LearningSysInfo.SaveLinkOfStuLes();
                //还应当存储当前已学完的课程
                break;
            default:break;
        }
    }
}