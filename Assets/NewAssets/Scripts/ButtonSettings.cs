using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour
{
    //重置相机使用变量
    private GameObject t;
    private CameraController cc;
    //以上为重置相机


    //切换场景
    public void InGaming()
    {
        SaveCurrentInfo();
        SceneManager.LoadScene("InGaming");
    }
    public void StartNewGame()
    {
        SaveCurrentInfo();
        SceneManager.LoadScene("NewGame");
    }
    public void LoadPlay()
    {
        SaveCurrentInfo();
        SceneManager.LoadScene("FirstTry");
    }
    public void BackToMenu()
    {
        SaveCurrentInfo();
        SceneManager.LoadScene("Start Menu");
    }

    public void ExitGame()
    {
        SaveCurrentInfo();
        Application.Quit();
    }
    //操纵相机视角
    public void ResetCamera()
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(0,0);
    }
    private void SaveCurrentInfo()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "NewGame":
                GameObject.Find("LoginSettings").GetComponent<LoginSettings>().SaveData();
                LocalInformation.ClearCurrents();
                break;
            default:break;
        }
    }
}