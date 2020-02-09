using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSettings : MonoBehaviour
{
    public GameObject t;
    public CameraController cc;
    //切换场景
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
    /*public void CameraLeft()
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(1);
    }
    public void CameraRight()
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(2);
    }
    public void CameraUp()
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(3);
    }
    public void CameraDown()
    {
        t = GameObject.FindGameObjectWithTag("MainCamera");
        cc = t.GetComponent<CameraController>();
        cc.CameraReset(4);
    }*/
}