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
        SceneManager.LoadScene("InGaming");
    }
    public void LoadSettingsInGaming()
    {
        SceneManager.LoadScene("SettingsInGaming");
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene("NewGame");
    }
    public void LoadMiNiJNU()
    {
        SceneManager.LoadScene("JNU");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    //操纵相机视角
    public void ResetCamera()
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(0,0);
    }
}